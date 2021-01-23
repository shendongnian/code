      <div>
        <asp:DropDownList ID="ddl_parent" runat="server" Width="160px" ></asp:DropDownList>
        <asp:TextBox ID="txtCategoryAdding" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" Text="Add Category" Width="100" runat="server" OnClick="btnAdd_Click"
        />
     </div>
       on page_load event on .cs page
      protected void Page_Load(object sender, EventArgs e)
          {
           SqlConnection conn = new  SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString);
        conn.Open();  
            SqlDataAdapter ad1 = new SqlDataAdapter();
            ad1.SelectCommand = new SqlCommand("select categoryID,categoryName from  
                       Categories_For_Merchant where parent_id=0",conn);
            ds = new DataSet();
            ad1.Fill(ds,"parent_cat");
            
            ddl_parent.DataSource = ds.Tables["parent_cat"];
            ddl_parent.DataTextField = "categoryID";
            ddl_parent.DataValueField = "categoryName ";
            ddl_parent.DataBind();
            ddl_parent.Items.Insert(0, new ListItem("Select", "0"));
            conn.close();
