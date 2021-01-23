    if( i==0)
    {
        LinkButton lnkbtn = new LinkButton();
        lnkbtn.Text = e.Row.Cells[7].Text;
       // Create a command button and link it to your id    
       // lnkbtn.CommandArgument = e.Row.Cells[0].Text; --Your Id 
       // lnkbtn.CommandName = "NumClick";
       // btn.Text = "view more";        
        e.Row.Cells[7].Controls.Add(lnkbtn);
    }
