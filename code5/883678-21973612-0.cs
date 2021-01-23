    List result = new List();
     do {
         try
           {
           GaData DataList = request.Execute();  // Make the request
           result.AddRange(DataList.Rows);       // store the Data to return later
           // hack to get next link stuff
          totalResults = (!DataList.TotalResults.HasValue) ? 0 : Int32.Parse(DataList.TotalResults.ToString());
           rowcnt = rowcnt + DataList.Rows.Count;
           NextLink = DataList.NextLink;                       
           request.StartIndex = rowcnt + 1 ;
           }
          catch (Exception e)
             {
              Console.WriteLine("An error occurred: " + e.Message);
              totalResults = 0;
             }
     } while (request.StartIndex <= totalResults);
