     static void Main(string[] args)
            {
                var sw = new Stopwatch();
                sw.Start();
                using (var context = new BHCSECLPEMEntities())
                {
                    var query = (from organizations in context.LargeSampleTable.AsNoTracking()
                                 where organizations.ErrorID != null
                                 orderby organizations.ErrorID
                                 select organizations);//large sample table
    
                    foreach (ApplicationErrorLog o in query)
                    {
                        writeRecord(o);
                    }
                    //do not use paging
                    //int recordCount = query.Count();
                    //int skipTo = 0;
                    //int take = 1000;
                    //if (recordCount > 0)
                    //{
                    //    while (skipTo < recordCount)
                    //    {
                    //        if (skipTo + take > recordCount)
                    //            take = recordCount - skipTo;
    
                    //        foreach (ApplicationErrorLog o in query.Skip(skipTo).Take(take))
                    //        {
                    //            writeRecord(o);
                    //        }
                    //        skipTo += take;
                    //    }
                    //} 
                }
                sw.Stop();
    
                Console.WriteLine("Completed after: {0}", sw.Elapsed);
                Console.ReadLine();
            }
    
            private static void writeRecord(ApplicationErrorLog o)
            {
                int i = 0;
            }
