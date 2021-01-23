    1. TaskId property not exist in DynamicColumns class.
    
    2. Remove .Replace("_", "") from
       var taskColum = Enum.GetValues(typeof(EnumTasks)).Cast<EnumTasks>().Where(e => fieldIds.Contains("," + ((int)e).ToString() + ",")).Select(e => e.ToString().Replace("_", ""));
    
    3.exportFields.Count should be > 0.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    
    namespace Dynamic
    {
        public class Program
        {
            public static List<DynamicColumns> DynamicColumnsCollection = new List<DynamicColumns>();
    
            static Program()
            {
                for (int i = 0; i < 10; i++)
                {
                    DynamicColumnsCollection.Add(new DynamicColumns() { Id = i, Name = "Name" + i, ip_address = "ip_" + i });
                }
            }
    
            static void Main(string[] args)
            {
                IQueryable collection = DynamicSelectionColumns(new List<string>() { "id", "name" });
    
                Console.ReadLine();
            }
    
            public class DynamicColumns
            {
                public int Id { get; set; }
    
                public string Name { get; set; }
    
                public string ip_address { get; set; }
            }
    
            public static IQueryable DynamicSelectionColumns(List<string> fieldsForExport)
            {
                if (!fieldsForExport.Any())
                    return null;
    
                string select = string.Format("new ( {0} )", string.Join(", ", fieldsForExport.ToArray()));
    
                var collection = DynamicColumnsCollection.Select(t => new DynamicColumns()
                {
                    Id = t.Id,
                    Name = t.Name,
                    ip_address = t.ip_address,
                }).ToList().AsQueryable().Select(select);
    
                return collection;
            }
        }
    }
