        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            GetEmpDetails()
        End Sub
        Private Sub GetEmpDetails()
        SqlConnection conn = new SqlConnection("Data Source=s\\SQLEXPRESS;Initial catalog = sample;Integrated security=True");
         
        conn.Open();
        
        cmd.CommandText = "SELECT * FROM Empdetails";
        GridView.DataSource = cmd.ExecuteReader();
        GridView.DataBind();
        End Sub
