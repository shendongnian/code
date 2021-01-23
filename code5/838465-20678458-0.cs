    protected void btnSubmit_Click(object sender, EventArgs e)
    {   
        // Submit - save the textboxes to Strings ??? Can any body help
        int DeviceCount = int.Parse(ViewState["DeviceCount"].ToString());
        for (int i = 0; i < DeviceCount; i++)
        {
          TextBox txtbx= (TextBox)div_insert_devices.FindControl("serial" + i);
          if(txtbx!=null)
          {
            var value= txtbx.Text;
          }
        }
    }        
       
