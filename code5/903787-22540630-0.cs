    <asp:GridView ID="ctlGridView" runat="server" OnRowCreated="OnRowCreated" />
    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
       { 
        DataRowView drv = e.Row.DataItem as DataRowView;
        Object ob = drv["return_date"];
        Object ob1 = drv["borrow_date"];
        if (!Convert.IsDBNull(ob) && !Convert.IsDBNull(ob1) )
        {
           DateTime date1return_date;
            DateTime date2borrow_date;
             if (DateTime.TryParse(ob.ToString(), out date1return_date) && 
                       DateTime.TryParse(ob1.ToString(), out date2borrow_date))
             {
                 if (date1return_date > date2borrow_date)
                 {
                     TableCell cell = e.Row.Cells[1]; // Get your required cell
                     cell.BackColor = System.Drawing.Color.Red;
                 }
             }
        }
      }
