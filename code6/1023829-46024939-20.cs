    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Linq;
    
    namespace DataFlex
    {
        /// <summary>
        /// Classes for parsing DataFlex DAT files version 3.0
        /// </summary>
        public enum DFFieldType
        {
            ASCII = 0,
            Numeric = 1,
            Date = 2,
            Overlap = 3,
            Unknown = 4
        }
    
        public class DFField
        {
            public DFFieldType Type;
            public Type DataType;
            public int Position;
            public byte Length;
            public decimal Precision;
            public string Name;
            private Byte[] _input;
    
            public DFField(byte[] input, string name)
            {
                _input = input;
                Name = name;
    
                UInt16 helper = BitConverter.ToUInt16(input, 0);
                Position = helper;
                helper = (ushort)((input[2]  & 0x0F) * 2);
                if (helper > 0)
                    Precision = (decimal)Math.Pow(10, helper);
                else
                    Precision = 0;
                Length = input[3];
                switch (input[4])
                {
                    case 0: Type = DFFieldType.ASCII; DataType = typeof(string); break;
                    case 1: Type = DFFieldType.Numeric; DataType = typeof(decimal); break;
                    case 2: Type = DFFieldType.Date; DataType = typeof(DateTime); break;
                    case 3: Type = DFFieldType.Overlap; DataType = typeof(object);  break;
                    default: Type = DFFieldType.Unknown; break;
                }
            }
        }
    
        public class DFRow
        {
            public object[] _values;
            public DFTable _DFTable;
            public object[] Values { get { return _values; } }
    
            public DFRow(byte[] input, DFTable dFTable)
            {
                _DFTable = dFTable;
                _values = new object[dFTable.Fields.Length];
                for (int i = 0; i < dFTable.Fields.Length; i++)
                {
                    var f = dFTable.Fields[i];
                    object o;
                    switch (f.Type)
                    {
                        case DFFieldType.Date: o = BCDToDate(input, f.Position - 1, f.Length); break;
                        case DFFieldType.Numeric: o = BCDToDecimal(input, f.Precision, f.Position - 1, f.Length, true); break;
                        default:  o = System.Text.Encoding.GetEncoding("ibm852").GetString(input, f.Position - 1, f.Length).TrimEnd();  break;
                    }
                    _values[i] = o;
                }
            }
    
            private decimal BCDToDecimal(byte[] input, decimal precision, int start, int length, bool signed)
            {
                decimal result = 0;
                uint i = 0;
                for (i = 0; i < length; i++)
                {
                    if (i > 0 || !signed)
                    {
                        result *= 100;
                        result += (decimal)(10 * (input[start + i] >> 4));
                    }
                    else
                    {
                        result *= 10;
                    }
                    result += (decimal)(input[start + i] & 0xf);
                }
    
                if (precision > 0)
                    result =  (result / precision);
    
                return (result);
            }
    
            private DateTime? BCDToDate(byte[] input, int start, int length)
            {
                DateTime baseDate = new DateTime(1642, 09, 14);
                decimal baseNumber = 700000;
                decimal dn = BCDToDecimal(input, 0, start, length, false);
                dn = dn - baseNumber;
    
                DateTime? result = null;
                if (dn > 0)
                {
                    result = baseDate.AddDays((double)dn);
                }
                return result;
            }
        }
    
        public class DFTable
        {
            private long _beginning = 0xC00;
            private UInt32 _RecordCount;
            private DFField[] _Fields;
            private List<DFRow> _Rows;
            private UInt16 _RecordLength = 0;
            private byte _FieldCount = 0;
            private string[] _tags = null;
    
            public DFField[] Fields
            {
                get { return _Fields; }
            }
            public List<DFRow> Rows
            {
                get { return _Rows; }
            }
    
            public DFRow LastRecord
            {
                get { return  Rows[Rows.Count-1]; } 
            }
    
        public DFTable(Stream datStream, bool readLastRecordOnly, string tagFile, string tableName)
        {
            if (File.Exists(tagFile))
                _tags = File.ReadLines(tagFile).ToArray();
            //Parsing header
            byte[] input = new byte[4];
            datStream.Read(input, 0, 4);
            _RecordCount = BitConverter.ToUInt32(input, 0);
            datStream.Seek(0x9A, SeekOrigin.Begin);
            datStream.Read(input, 0, 2);
            _RecordLength= BitConverter.ToUInt16(input, 0);
            datStream.Seek(0xA5, SeekOrigin.Begin);
            datStream.Read(input, 0, 1);
            _FieldCount = input[0];
            datStream.Seek(0x2E0, SeekOrigin.Begin);
            _Fields = new DFField[_FieldCount];
            //Parsing structure
            int i;
            for (i = 0; i < _FieldCount; i++)
            {
                input = new byte[8];
                datStream.Read(input, 0, 8);
                string name = _tags == null || _tags.Length<=i ? "F" + i.ToString() : _tags[i];
                _Fields[i] = (new DFField(input, name));
            }
            _beginning = 0xC00 + _RecordLength;  //Allways starts at C00
            _Rows = new List<DFRow>();
            input = new byte[_RecordLength];
            if (readLastRecordOnly)
            {
                for (int idx = 1; idx < _RecordCount; idx++)
                {
                    datStream.Seek(_beginning + (_RecordCount - idx) * _RecordLength, SeekOrigin.Begin); //Set the last record
                    datStream.Read(input, 0, _RecordLength);
                    if (input.Any(x => x != 0))  //Not deleted - not all zeroes
                    {
                        _Rows.Add(new DFRow(input, this));
                        break;
                    }
                }
            }
            else
            {
                datStream.Seek(_beginning, SeekOrigin.Begin); //Go to beginning
                for (int row = 0; row < _RecordCount; row ++)
                {
                    datStream.Read(input, 0, _RecordLength);
                    if (input.Any(x=>x!=0))  //Not deleted
                        _Rows.Add(new DFRow(input, this));
                }
            }
        }
    
            /// <summary>
            /// Převede na DataTable 
            /// </summary>
            /// <returns></returns>
            public DataTable ToDataTable()
            {
                DataTable dt = new DataTable();
                DataColumn dc;
                for (int i=0; i< this.Fields.Length; i++)
                {
                    var f = this.Fields[i];
                    dc = new DataColumn(f.Name, f.DataType ); 
                    dt.Columns.Add(dc);
                }
    
                //Záznamy od prvního
                foreach (var r in this.Rows)
                {
                    DtaRow dr = dt.NewRow();
                    int j = 0;
                    foreach (object v in r.Values)
                    {
                        dr[j] = v ?? DBNull.Value;
                        j++;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
    
            /// <summary>
            /// https://stackoverflow.com/a/4959869/2224701
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="csvFileName"></param>
            public void SaveAsCSV(string csvFileName, bool header)
            {
                StringBuilder sb = new StringBuilder();
                if (header)
                {
                    IEnumerable<string> columnNames = this.Fields.
                                                      Select(column => column.Name);
                    sb.AppendLine(string.Join(",", columnNames));
                }
                foreach (DFRow row in this.Rows)
                {
                    IEnumerable<string> fields = row.Values.Select(field =>
                      string.Concat("\"", field!=null ?  (field is DateTime ? ((DateTime)field).ToShortDateString() :  field.ToString()).Replace("\"", "\"\"") : "", "\""));
                    sb.AppendLine(string.Join(",", fields));
                }
                File.WriteAllText(csvFileName, sb.ToString());
            }
        }
    }
