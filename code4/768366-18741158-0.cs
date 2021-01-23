    public class line
    {
      public int ItemNumber { get; set; }
      public string ProductStatus { get; set; }
      public int UPC { get; set; }
      public line(string currLine)
      {
         string[] cells = currLine.Split('|');
         int item;
         if(int.TryParse(cells[0], out item))
         {
            ItemNumber = item;
         }
         ProductStatus = cells[1];
         int upc;
         if (int.TryParse(cells[2], out upc))
         {
            UPC = upc;
         }
      }
    }
