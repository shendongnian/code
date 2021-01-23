    `
    
    using System.Data;   
    using System.Data.SqlClient;
    
    
    string sConnectionString = @"Data Source=myServerName\myInstanceName;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";
    
    
    protected void Page_Load(object sender, EventArgs e){
    
    if(!IsPostBack){  
     BindGridView();   
    }
    
    }
    
    
    
    private void BindGridView()
    {             
    DataTable dt = new DataTable();           
    SqlConnection con = null;         
    try{
    
    string sQuery = "SELECT ID, Name, Salary FROM EmpDetail";
    
    
    SqlConnection con = new SqlConnection(sConnectionString);
    
    con.Open();
    
    SqlCommand cmd = new SqlCommand(sQuery , con); 
    
    SqlDataReader sdr = cmd.ExecuteReader();
    
    
    
    dt.Load(sdr);
    
    Gridview1.DataSource = dt;
    
    Gridview1.DataBind();
    
    }
    catch{
    
    
    }
    
    finally{
    
    dt.Dispose();
    
    con.Close();
    
    }
    
    }
    
    `
