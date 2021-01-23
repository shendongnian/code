    foreach (GridViewRow Row in GridviewDevicesBulkUpdate.Rows)
     {
        if (Row.RowType == DataControlRowType.DataRow)
        {
        CheckBox chkUpdate = (CheckBox)Row.FindControl("CheckBoxIncludes");
       
    
         if (chkUpdate.Checked == true)
            {
             string DeviceID = Row.Cells[0].Text.Trim();
             if (ManageTransport.ManageDevices.UpdateAllDevices(IsCardPwdUpdated, SoftwareVersion, IsActive, int.Parse(DeviceID)))
             {
               Response = true;
             }
             else
             {
             Response= false;
             }
          }
        }
        }
