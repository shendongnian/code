    protected void ButtonNext_Click(object sender, EventArgs e)
    {
     ++gridview.PageIndex;  
    
     // if we have reached the last page, either set to first page. 
     // you could also do nothing.
     if (gridview.PageIndex >= gridview.PageCount)
     {
      gridview.PageIndex = 0;
     }
           
     gridview.DataSource = GetGridViewData(); // the data needs to be available.
     
     gridview.DataBind(); 
    }
