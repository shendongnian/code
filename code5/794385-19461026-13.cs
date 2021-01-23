    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                // Call ConvertTable here
            }
    
            private static IEnumerable<T> Map<T>(SqlDataReader dr) where T : new()
            {
                var enumerableDataReader = dr.Cast<DbDataRecord>().AsEnumerable();
                var tObj = new T();
                PropertyInfo[] propertyInfo = tObj.GetType().GetProperties();
                var batches = enumerableDataReader.Batch(10000);
    
                var resultCollection = new ConcurrentBag<List<T>>();
                Parallel.ForEach(batches, batch => resultCollection.Add(MapThis<T>(propertyInfo, batch)));
    
                return resultCollection.SelectMany(m => m.Select(x => x));
            }
    
            private static List<T> MapThis<T>(PropertyInfo[] propertyInfo, IEnumerable<DbDataRecord> batch) where T : new()
            {
                var list = new List<T>();
                batch.AsParallel().ForAll(record =>
                {
                    T obj = new T();
                    foreach (PropertyInfo prop in propertyInfo)
                    {
                        var dbVal = record[prop.Name];
                        if (!Equals(dbVal, DBNull.Value))
                        {
                            prop.SetValue(obj, dbVal, null);
                        }
                    }
                    list.Add(obj);
                });
                return list;
            }
        }
    
        public static class Extensions
        {
            /// <summary>
            /// Take a collection and split it into smaller collections
            /// </summary>
            /// <typeparam name="T">The Type</typeparam>
            /// <param name="collection">The collection to split</param>
            /// <param name="batchSize">The size of each batch</param>
            /// <returns></returns>
            public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> collection, int batchSize)
            {
                var nextbatch = new List<T>(batchSize);
                if (collection == null)
                {
                    yield break;
                }
                foreach (T item in collection)
                {
                    nextbatch.Add(item);
                    if (nextbatch.Count != batchSize)
                    {
                        continue;
                    }
                    yield return nextbatch;
                    nextbatch = new List<T>(batchSize);
                }
                if (nextbatch.Count > 0)
                {
                    yield return nextbatch;
                }
            }
        }
    }
