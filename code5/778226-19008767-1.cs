    protected void Page_Load(object sender, EventArgs e)
    {
    Employee emp = null;
    List<Employee> listEmployee = new List<Employee>();
    for (int i = 0; i < 1; i++)
    {
        emp = new Employee();
        emp.ID = i;
        //emp.Age = "Age :" + i.ToString();
        //emp.Location = "Location :" + i.ToString();
        listEmployee.Add(emp);
    }
    Gridview1.DataSource = listEmployee;
    Gridview1.DataBind();
     }
      protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
      {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        var txtkms = e.Row.FindControl("txtkms") as TextBox;
        var txtrateperkm = e.Row.FindControl("txtrateperkm") as TextBox;
        var billamt = e.Row.FindControl("billamt") as TextBox;
        var jsFunction = String.Format("CalculateBillAmount('{0}','{1}','{2}');", txtkms.ClientID, txtrateperkm.ClientID, billamt.ClientID);
        txtkms.Attributes.Add("onkeyup", jsFunction);
        txtkms.Attributes.Add("onblur", jsFunction);
        txtrateperkm.Attributes.Add("onkeyup", jsFunction);
        txtrateperkm.Attributes.Add("onblur", jsFunction);
    }
    }
     class Employee
     {
     public int ID { get; set; }
     }
