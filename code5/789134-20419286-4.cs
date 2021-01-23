     public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
     {
         // Set the value of the editing control to the current cell value. 
         base.InitializeEditingControl(rowIndex, initialFormattedValue,
             dataGridViewCellStyle);
         ctl = DataGridView.EditingControl as CalendarEditingControl;
         // ctl.Invalidated += new InvalidateEventHandler(ctl_Invalidated);
         ctl.ValueChangedSpecial += new EventHandler(ctl_ValueChangedSpecial);
         if (rowIndex >= 0)
         {
             try
             {                    
                 if (String.IsNullOrEmpty(this.Value.ToString()))
                 {
                     ctl.Checked = false;
                     ctl.Format = DateTimePickerFormat.Custom;
                     ctl.CustomFormat = " ";
                 }
                 else
                 {
                     ctl.Checked = true;
                     ctl.Value = (DateTime)this.Value;
                     ctl.Format = DateTimePickerFormat.Short;            
                 }
             }
             catch (ArgumentOutOfRangeException aex)
             {
                 //MessageBox.Show("ERROR. " + aex.Message);
                 ctl.Value = (DateTime)this.DefaultNewRowValue;
             }
         }
     }
