     var returnData = (from p in db.r2_search_general_source select p);
    
    if(!String.ISNullOrWhiteSpace(txtCompany.Text)) 
    { 
    
    returnData = returnData.Where(x=>x.SomeColumn == txtCompany.Text);
    }
    
    if(!String.ISNullOrWhiteSpace(txtPostcode.Text))
    {
    returnData = returnData.Where(x=>x.SomeColumn == txtPostcode.Text);
    }
                     
