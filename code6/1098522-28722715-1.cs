     Excel.Range r = ExcelSheet.Range["B2", "B4"];
     object[,] workingValues = new object[3, 1];
     for (int i = 0; i < 3; i++)
     {
          workingValues[i, 0] = i + 2;  // 2,3,4 
     }
 
     r.Value2 = workingValues;
