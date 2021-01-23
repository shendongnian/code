    using System.Linq; //SequenceEqual
    
     byte[] FirstExcelFileBytes = null;
     byte[] SecondExcelFileBytes = null;
    
     FirstExcelFileBytes = GetFirstExcelFile();
     SecondExcelFileBytes = GetSecondExcelFile();
    
     if (FirstExcelFileBytes.SequenceEqual<byte>(SecondExcelFileBytes) == true)
     {
          MessageBox.Show("Arrays are equal");
     }
     else
     {
         MessageBox.Show("Arrays don't match");
     }
