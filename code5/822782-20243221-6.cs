    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
       var query = from myRow in myDataTable.AsEnumerable()
                where r.Field<string>("EmployeeName")==TextBox2.Text
                select new
                {
                    EmployeeID = myRow.Field<int>("EmployeeID"),
                    Weight = contact.Field<int>("Weight"),
                    Amount = order.Field<double>("Amount")
                };
        foreach (var row in query)
        {
           txtBoxId.Text = row.Employee.ToString();
           txtboxw.Text = row.Weight.ToString();
           txtboxam.Text = row.Amount.ToString();
        }
    }
      
