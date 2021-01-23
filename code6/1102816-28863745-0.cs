    Media currentItem = null;
    while ((mediaRow = mediaData.ReadLine()) != null) // as long as there is more string data, the loop while continue
    {
         if (mediaRow.StartsWith("BOOK"))
         {
             // Do you book processing...
             books[bookCount] = new Book(dataSplit[1].Trim(), year, dataSplit[3].Trim());
             currentItem = books[bookCount];
             // ....
         }
         else if (mediaRow.StartsWith("SONG"))
         {
             // Do song processing
         } 
         else if (mediaRow.StartsWith("MOVIE"))
         {
             // Do movie processing
         }
         else
         {
             // this must be a summary for the previous item
             // assuming Media has a summary property:
             currentItem.Summary = mediaRow;
         }
    }
