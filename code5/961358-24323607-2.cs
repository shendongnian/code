    private void ClearNotVisibleImages()
    {
       foreach(var row in this.GetNotVisibleDataRowsWithImages())
       {
          var cell = row["Image"];      
          Image image = (Image)(cell .Content);           
          
          cell.Content = null;
          image.Dispose();
       }
    
       
       // If it will be really needed
       GC.Collect();
       // Improved Thanks @rentanadviser
       GC.WaitForPendingFinalizers();
       GC.Collect();
    }
