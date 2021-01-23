    int totalCount = lstDKCZ.Count * lstPTST.Count;
    Parallel.ForEach(lstDKCZ, item =>
        {
            Parallel.ForEach(lstPTST, item2 =>
                {
                    //Lots of SQL queries and whatnot
                    double iCount = overview.Count();
                    double iCounter = 0;
                    foreach(var item3 in overview)
                    {
                        //Again lots of things happening
                        if (DateTime.Now > dtTime2.AddMilliseconds(15))
                        {
                            if (iCounter != iCount)
                                progress.Report(Convert.ToInt32((iCounter / iCount) * 100 / totalCount);
                            dtTime2 = DateTime.Now;
                        }
                    }
              }
       }
