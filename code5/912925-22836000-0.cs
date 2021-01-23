        public static void CompareBookmarks(string MyPDf, List<string> MyTitles)
        {
          PdfReader reader = new PdfReader(MyPdf);
          IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(reader);
          foreach (Dictionary<string, object> itemBookmark in bookmarks)
           {
            KeyValuePair<string, object> firstPairOfDictionary = item.FirstOrDefault();
                   foreach (var title in myTitles)
                   {
                      if (firstPairOfDictionary.Value != title.ToString())
                       {
                           Console.WriteLine("Did not found");
                           continue;
                       }
                       break;
                   }
         }
