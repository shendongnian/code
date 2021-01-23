    private NewEmployeeForm()
    {
      InitializeComponent();
    }
    public static EmployeeClass ShowDialog()
    {
      var frm = new NewEmployeeForm();
      while (frm.ShowDialog() == DialogResult.OK)
      {
        if (string.IsNullOrEmpty(frm.tbxName.Text))
        {
          MessageBox.Show("Please, enter the employee name.");
        }
        else
        {
          var emp = new EmployeeClass();
          emp.Id = int.Parse(frm.tbxId.Text);
          emp.Name = frm.tbxName.Text);
          return emp;
        }
      }
      return null;
    }
