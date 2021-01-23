    StringBuilder sb=new StringBuilder();
    DateTime date = System.DateTime.Today;
    String strdate = date.ToString("dd-MM-yy");
    sb.append(" DATE_FORMAT(tblhomework.DateCreated,'%d-%m-%y')='" + strdate);
    
    if(drpclass.SelectedIndex != 0)
    {
    //sb.append("ClassName='"+ drpclass.SelectedValue.Text + "'")
    }
    if(string.isEmptyorNull(txtTecher.Text))
    {
    //sb.append("TeacherName='" +txtTecher.Text+"'")
    }
    //write other condition 
    //Sql Query="select * from  where"+sb.toString();
