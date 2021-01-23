    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Data;
    
    namespace SupervisionP
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
    
            public DFField(byte[] input)
            {
                _input = input;
    
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
                        default:  o = System.Text.Encoding.GetEncoding("ibm852").GetString(input, f.Position - 1, f.Length);  break;
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
            //private UInt32 _LastRecOffset;
            private UInt32 _RecordCount;
            private DFField[] _Fields;
            private List<DFRow> _Rows;
            private UInt16 _RecordLength = 0;
            private byte _FieldCount = 0;
    
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
    
            public DFTable(Stream datStream, bool readLastRecordOnly)
            {
                //Parsujeme hlavičku
                byte[] input = new byte[4];
                datStream.Read(input, 0, 4);
                _RecordCount = BitConverter.ToUInt32(input, 0);
                datStream.Seek(0xA5, SeekOrigin.Begin);
                datStream.Read(input, 0, 1);
                _FieldCount = input[0];
                datStream.Seek(0x2E0, SeekOrigin.Begin);
    
                _Fields = new DFField[_FieldCount];
                //Parsujeme strukturu
                int i;
                for (i = 0; i < _FieldCount; i++)
                {
                    input = new byte[8];
                    datStream.Read(input, 0, 8);
                    _Fields[i] = (new DFField(input));
                }
    
    
                //Parsujeme záznamy
                long totalLength = datStream.Length;
                _RecordLength = (ushort)((totalLength - 0xC00) / _RecordCount);
                _Rows = new List<DFRow>();
                input = new byte[_RecordLength];
    
                if (readLastRecordOnly)
                {                 
                    datStream.Seek(0xC00 + (_RecordCount)*_RecordLength, SeekOrigin.Begin); //Nastavit na poslední
                    datStream.Read(input, 0, _RecordLength);
                    _Rows.Add(new DFRow(input, this));
                }
                else
                {
                    datStream.Seek(0xC00 + _RecordLength, SeekOrigin.Begin); //Nastavit na začátek
    
                    for (int row = 0; row < _RecordCount; row ++)
                    {
                        datStream.Read(input, 0, _RecordLength);
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
                    dc = new DataColumn("F" + i.ToString(), f.DataType ); //Bez TAG souboru neznáme názvy sloupců
                    dt.Columns.Add(dc);
                }
    
                //Záznamy od prvního
                foreach (var r in this.Rows)
                {
                    DataRow dr = dt.NewRow();
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
        }
    }
