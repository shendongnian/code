    if( i==0)
    {
        LinkButton lnkbtn = new LinkButton();
        lnkbtn.Text = e.Row.Cells[7].Text;
       // btn.Text = "view more";        
        e.Row.Cells[7].Controls.Add(btn);
    }
