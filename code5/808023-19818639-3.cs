     static void Main(string[] args)
            {
                var sw = new Stopwatch();
                sw.Start();
                using (var context = new MyEntities())
                {
                    var query = (from organizations in context.LargeSampleTable.AsNoTracking()
                                 where organizations.ErrorID != null
                                 orderby organizations.ErrorID
                                 select organizations);//large sample table, 146994 rows
    
                    foreach (MyObject o in query)
                    {
                        writeRecord(o);
                    }
                }
                sw.Stop();
    
                Console.WriteLine("Completed after: {0}", sw.Elapsed);
                Console.ReadLine();
            }
    
            private static void writeRecord(ApplicationErrorLog o)
            {
                ;
            }
