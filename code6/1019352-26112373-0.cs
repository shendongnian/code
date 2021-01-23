    foreach (GridViewRow grdRow in dataGridView1.Rows)
    {
    CheckBox chk = new CheckBox();
    int count=0;
    chk = (CheckBox)grdRow.FindControl("check box name");
    if (chk != null && chk.Checked == true)
    { 
        //write code for insesrt
        count++;
    }
    }
    if(count==0)
    {
       MessageBox.Show("Select one checkbox");
    }
