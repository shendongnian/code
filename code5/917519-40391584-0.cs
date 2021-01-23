    
    HtmlElement myTableElement;
    //Set myTableElement using any GetElement...  method.
    //Use a loop or square bracket index if the method returns an HtmlElementCollection.
    dynamic myTable = myTableElement.DomElement;
    for (int i = 0; i < myTable.rows.length; i++)
    {
        for (int j = 0; j < myTable.rows[i].cells.length; j++)
        {
            string CellContents = myTable.rows[i].cells[j].innerText;
            //You are not limited to innerText; you have the whole DOM available.
            //Do something with the CellContents.
        }
    }
    
