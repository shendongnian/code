       foreach (GridViewRow grow in gvServiceProviders.Rows)
        {
           //Make sure it is datarow
           if(grow.RowType = RowType.DataControlRowType.DataRow)
           {
              //Finiding checkbox control in gridview for particular row
              CheckBox chkdelete = (CheckBox)grow.FindControl("cbSelect");
              //Make sure if checkbox is selected for the processing row
              if(chkdelete.Checked)
              {
                //Getting your datakey value
                bll.ServiceProviderLocationID = Convert.ToInt32(gvServiceProviders.DataKeys[grow.RowIndex].Value);
                bll.IsDeleted = "y";
                bll.ServiceProviderLocationDelete(); 
              }             
           }
        }
        gvServiceProviders.DataSource = bll.GetServiceProviderLocations();
        gvServiceProviders.DataBind();
        
