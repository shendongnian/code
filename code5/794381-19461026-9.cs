    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static readonly SqlToObjectReflectionMappingService MappingService = new SqlToObjectReflectionMappingService();
    
            private static void Main(string[] args)
            {
                // Call ConvertTable here...
            }
    
            private static IEnumerable<T> ConvertTable<T>(DataTable dataTable) where T : new()
            {
                return MappingService.DataTableToObjects<T>(dataTable);
    
            }
    
            public class SqlToObjectReflectionMappingService : ISqlToObjectMappingService
            {
                public T DataRowToObject<T>(DataRow row, PropertyDescriptorCollection propertyDescriptorCollection)
                    where T : new()
                {
                    var obj = new T();
                    foreach (PropertyDescriptor propertyDescriptor in propertyDescriptorCollection)
                    {
                        propertyDescriptor.SetValue(obj, row[propertyDescriptor.Name]);
                    }
                    return obj;
                }
    
                public IEnumerable<T> DataTableToObjects<T>(DataTable table) where T : new()
                {
                    var obj = new T();
                    var props = TypeDescriptor.GetProperties(obj);
                    return table.AsEnumerable().AsParallel().Select(m => DataRowToObject<T>(m, props));
                }
            }
    
            public interface ISqlToObjectMappingService
            {
                T DataRowToObject<T>(DataRow row, PropertyDescriptorCollection propertyDescriptorCollection) where T : new();
                IEnumerable<T> DataTableToObjects<T>(DataTable table) where T : new();
            }
        }
    }
