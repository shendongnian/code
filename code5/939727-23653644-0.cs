    public partial class Somepage : System.Web.UI.Page
    {
    	public string GetData()
    	{
    		SqlConnection con = new SqlConnection("Data Source=COMP7;Initial Catalog=GK_Practice;User ID=sa;Password=SQLEXPRESS");
    		SqlCommand cmd = new SqlCommand();
    		cmd.Connection = con;
    		cmd.CommandType = CommandType.Text;
    		cmd.CommandText = "select * from employee";
    		con.Open();
    
    		SqlDataReader rd = cmd.ExecuteReader();
    
    		int rowcount=0, columncount;
    
    		while(rd.Read())
    		{
    			rowcount++;            
    		}
    
    		columncount = rd.FieldCount;
    		rd.Close();
    		rd = cmd.ExecuteReader();
    
    		string[][] str=new string[rowcount][];
    		int i = 0;
    		while(rd.Read())
    		{
    		   str[i] = new string[columncount];
    		   for (int j = 0; j < columncount; j++)
    		   {
    			   str[i][j] = rd.GetValue(j).ToString();
    		   }
    		   i++;
    		}
    
    		Label2.Text = str[1][1].ToString();
    		JavaScriptSerializer js = new JavaScriptSerializer();
    		string json = js.Serialize((object)str);
    		rd.Close();
    		con.Close();
    		
    		return json;
    	}
    	
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		// Just to feel you this is code behind
    	}
    }
