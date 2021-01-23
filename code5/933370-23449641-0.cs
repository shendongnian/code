    List<string> YourList = new List<string>();
    //fill your list 
    
    object oMissing = System.Reflection.Missing.Value;        
    // get your table or create a new one like this
    // the number '2' is the rows number 
    Microsoft.Office.Interop.Word.Table myTable = oWordDoc.Add(myRange, 2,numberOfColumns)
    int rowCount = 2; 
    //add a row for each item in a collection.
    foreach( var s in YourList)
    {
       myTable.Rows.Add(ref oMissing)
       // do somethign to the row here. add strings etc. 
       myTable.Rows.[rowCount].Cells[1].Range.Text = "Content of column 1";
       myTable.Rows[rowCount].Cells[2].Range.Text = "Content of column 2";
       myTable.Rows[rowCount].Cells[3].Range.Text = "Content of column 3";
       //etc
    }
