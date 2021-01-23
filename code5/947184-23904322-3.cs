    private void SetStatusImage(CustomColumnDataEventArgs e)
        {
            DataModel.TaskToConfirm task = e.Row as DataModel.TaskToConfirm;            
            if (task.BillingConfirmed)
                e.Value = imageListGrid.Images[0];
            else
                e.Value = imageListGrid.Images[1];
        }
    
    private void SetPunctualityImage(CustomColumnDataEventArgs e)
        {
            DataModel.TaskToConfirm task = e.Row as DataModel.TaskToConfirm;
    
            if (task.PunctualityStatus == (int)ePunctuality.Extra)
                e.Value = CareGiver.Properties.Resources.Cancelled_Image;
            else if (task.PunctualityStatus == (int)ePunctuality.Less)
                e.Value = CareGiver.Properties.Resources.Update_CSD;
            else
                e.Value = CareGiver.Properties.Resources.Category_Green;
     
        }
    
    private void SetAttendanceImage(CustomColumnDataEventArgs e)
        {
            DataModel.TaskToConfirm task = e.Row as DataModel.TaskToConfirm;
    
            if (task.AttendanceType == 2)
                e.Value = imageList1.Images["auto"];
            else if (task.AttendanceType == 1)
                e.Value = imageList1.Images["manual"];
            else if (task.AttendanceType == 0)
                e.Value = imageList1.Images["default"];
                
     
        }
