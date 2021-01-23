    private void SaveButton_Click(object sender, EventArgs e)
       {
         if (MyParentform.GetInvalidControl() == null)
           {
             BindingSource1.EndEdit();
             MyManager.UpdateAll(MyDataset);
           }
         else
           {
             Messagebox.Show(string.Format("Control {0} failed", MyParentform.GetInvalidControl().Name))
           }
       }
