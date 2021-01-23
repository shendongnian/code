    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <img src='images/<%#DataBinder.Eval(Container.DataItem,"images") %>' height="150" width="150" alt="" border="0" />
        <asp:Literal ID="Literal1" runat="server" Value='<%#DataBinder.Eval(Container.DataItem,"id") %>'></asp:Literal>
    	</br>
    	</ItemTemplate>
    </asp:Repeater>
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["constring"].ConnectionString);
    SqlDataAdapter adap;
    DataSet ds;
    string Query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            binddata();
        }
    }
    
    protected void binddata()
    {
        string str = "select * from photos";
        SqlCommand cmd = new SqlCommand(str, con);
    
        adap = new SqlDataAdapter(str, con);
        ds = new DataSet();
        adap.Fill(ds);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
    	con.Open();
    	String mySQL;
    	try
    	{
    		for (int i = 0; i < Repeater1.Items.Count; i++)
    		{
    			CheckBox CheckBox1 = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1")
    			Literal litMessageId = (Literal)Repeater1.Items[i].FindControl("literal1");
    			
    			if (CheckBox1 != null && litMessageId != null && CheckBox1.Checked)
    			{
    				string Id = litMessageId.Text;
    				mySQL = string.Format("delete from photos where id = '{0}'", Id);
    
    				SqlCommand cmdDelete = new SqlCommand(mySQL, con);
    				cmdDelete.ExecuteNonQuery();
    				
    				// Continue your code here
    			}
    			else
    			{
    
    			}
    		}
    	}
        catch
    	{
    		Label2.Text = "error";
    	}
    }
