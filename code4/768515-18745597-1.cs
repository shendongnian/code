    private static readonly Lazy<string> ConnectionString = new Lazy<string>(() => WebConfigurationManager.ConnectionStrings["walkin2"].ConnectionString);
    private const string GetEmployeeBySSNQuery = "SELECT dbo.table_name.SSN, dbo.table_name.LAST_NAME, dbo.table_name.FIRST_NAME, dbo.table_name.MIDDLE_INITIAL, dbo.table_name.COMPONENT_CODE, dbo.table_name.PRESENT_CODE FROM dbo.table_name INNER JOIN dbo.table_name ON dbo.table_name.SSN = @SSN";
    protected void Page_Load(object sender, EventArgs e)
    {
        // ...
        if(!IsPostBack)
        {
            GetEmployeeInformation();
        }
    }
    
    private void GetEmployeeInformation()
    {
        var sctTextBox = (TextBox)Page.PreviousPage.FindControl("Txtsct");
        Txtsct.Text = txtsct.Text; 
        var ssnTextBox = (TextBox)Page.PreviousPage.FindControl("Txtssn");
        Txtssn.Text = ssnTextBox.Text;
        
        var ssn = ssnTextBox.Text;
        
        var employee = GetEmployeeBySSN(ConnectionString.Value, ssn);
        
        if(employee != null)
        {
            LblFName.Text = employee.FirstName;
            LblLName.Text = employee.LastName;
        }
    }
    
    private Employee GetEmployeeBySSN(string connectionString, string ssn)
    {
        Employee employee = null;
        
        using(var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(var command = new SqlCommand(GetEmployeeBySSNQuery, connection)
            {
                command.Parameters.AddWithValue("@SSN", ssn);
                
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        employee = new Employee
                                    {
                                        FirstName = Convert.ToString(reader["FIRST_NAME"]),
                                        LastName = Convert.ToString(reader["LAST_NAME"])
                                    };
                    }
                }
            }
        }
        
        return employee;
    }
