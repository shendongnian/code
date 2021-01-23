     if (myTable != null)
        {
            int iRow=0;
            var tableRows = myTable
                         .Descendants("tr");
 
            foreach (var tableRow in tableRows)
            {
                 var rowCells = tableRow
                         .Descendants("td");
                         
                 int iColumn=0;
                 foreach (var cell in rowCells)
                 {
                    //Save to Excel code
                    //Perform any checks here to ensure youre getting a valid value from the cell contents
                    //Excel.Cell[iRow,iColumn++]=cell.InnerText;
                 }
                 iRow++;
            }
        }
    }
