      if (!System.IO.File.Exists(@"C:\test2.xls"))
      {
       xlWorkBook.SaveAs(@"c:\test2.xls"); 
      }
      else
      {
       xlWorkBook.SaveAs(@"c:\test2(Copy).xls"); 
      }  
