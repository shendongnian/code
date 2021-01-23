    FrmAdd_To_Cart formToClose = null;
    var frmCartList = Application.OpenForms.OfType<FrmAdd_To_Cart>();
    if (frmCartList != null)
    {
        foreach(FrmAdd_To_Cart frm in frmCartList)
        {
            // Your logic could be based on the value that you set
            // in the Tag property when you create the form
            // For example you could have a CustomerID stored in the Tag
            // int customerID = Convert.ToInt32(frm.Tag);
            
            // But probably it is better to have custom public property 
            // in the definition of your FrmAdd_To_Cart form class like
            // if(frm.CustomerID == CurrentCustomer.ID)
            //   .....
            // Or if you want to close the form that you identify with the tag
            if (this.lblBil.Text == frm.Tag.ToString()) 
            {
                formToClose = frm;
                break; // exit the loop and then close                  
                // Can't do this here because this will change 
                // the iterating collection and this is not allowed
                // frm.Close();
            }
        }
        if (formToClose != null)
           formToClose.Close();
    }
