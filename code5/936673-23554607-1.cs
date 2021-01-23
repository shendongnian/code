    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    
    namespace MiniORM
    {
        //Attribute to map SQL result set field to class public instance property
        public class FieldInfo : Attribute
        {
            public string FieldName { get; set; }
            public Type DataType { get; set; }
        }
    
        public class MyRecord
        {
            [FieldInfo(DataType=typeof(int),FieldName="ID")]
            public int ID { get; set; }
            [FieldInfo(DataType = typeof(string), FieldName = "Name")]
            public string Name { get; set; }
            [FieldInfo(DataType = typeof(DateTime), FieldName = "DateCreated")]
            public DateTime DateCreated { get; set; }
            [FieldInfo(DataType = typeof(bool), FieldName = "IsSilly")]
            public bool IsSilly { get; set; }
    
            public override string ToString()
            {
                return string.Format("{0}-{1}-{2}-{3}", ID, Name, DateCreated, IsSilly);
            }
        }
    
        public class FieldInfoDBMapper<T> where T: class,new()
        {
            private readonly Dictionary<string,KeyValuePair<PropertyInfo,Type>> _mapping; 
    
            public FieldInfoDBMapper()
            {
                var t = typeof (T);
                _mapping = new Dictionary<string,KeyValuePair<PropertyInfo,Type>>();
                foreach (var pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    var infos = pi.GetCustomAttributes(typeof(FieldInfo));
                    if (infos.Any())
                    {
                        var fieldInfo = (FieldInfo) infos.First();
                        _mapping.Add(fieldInfo.FieldName,new KeyValuePair<PropertyInfo, Type>(pi,fieldInfo.DataType));
                    }
                }
    
            }
            public List<T> MapFromReader(IDataReader reader)
            {
                List<T> data = new List<T>();
                while (reader.Read())
                {
                    T item = new T();
                    foreach (var entry in _mapping)
                    {
                        var value = Convert.ChangeType(reader[entry.Key],entry.Value.Value);
                        entry.Value.Key.SetValue(item,value);
                    }
                    data.Add(item);
                }
                return data;
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                List<MyRecord> records  =new List<MyRecord>();
                using (
                    SqlConnection conn =
                        new SqlConnection("Your connection string here"))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand("Select * from MyRecords", conn))
                    {
                        var reader = comm.ExecuteReader();
                        var mapper = new FieldInfoDBMapper<MyRecord>();
                        records.AddRange(mapper.MapFromReader(reader));
                    }
                }
                foreach (var record in records)
                {
                    Console.WriteLine(record.ToString());
                }
                Console.ReadLine();
            }
        }
    }
