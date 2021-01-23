     TableRow tbRow= new TableRow();
     TableCell tbCell = new TableCell();
    
     HyperLink hyplnk= new HyperLink();
     hyplnk.NavigateUrl = "http://endor/RequestIT/Remee/test/Details.aspx";
     hyplnk.Text = (work / dda).ToString("p");
    
     tbCell.Controls.Add(hplink);
     tbRow.Controls.Add(tbCell);
     
     TableID.Controls.Add(tbRow); //TabledID is the ID you give the table in the ASPX page
