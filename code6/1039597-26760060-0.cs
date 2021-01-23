    Form MyEditForm;
    private void cell1_DoubleClick(object sender, System.EventArgs e)
    {
         if (MyEditForm==null)
         { 
             MyEditForm=new MyEditForm();
             MyEditForm.FormClosing += refreshData;
         }
         MyEditForm.ShowDialog();
    }
    private void refreshData(object sender, EventArgs e)
    {
         var myDataObj=MyEditForm.getData();
    }
