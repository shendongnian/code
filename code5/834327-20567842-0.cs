    repositoryItemRadioGroup1.Items.AddRange(new RadioGroupItem[] 
    {
         new RadioGroupItem(1, "Item1"),
         new RadioGroupItem(2, "Item2")
    });
    private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
    { 
        if(barEditItemRadio.EditValue==null)
           return;//Or do whatever 
        int editValue = (int)barEditItemRadio.EditValue;
        if(editValue ==1)//Item1 is selected 
        {
        total = ((a + b + c) - d).ToString("n2"); 
        }
        else if(editValue ==2)//Item2is selected 
        {
         total = (a + b + c).ToString("n2");
        }
    }
