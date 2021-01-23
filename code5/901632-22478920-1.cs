    using System.Data;
    using System.Configuration;
    using System.Data.SqlClient;
    using AjaxControlToolkit;
    
    //the page_onload add the following code
    
     if (!IsPostBack)
     {
            gvFruits.DataSource = GetData("SELECT FruitId, FruitName, ISNULL((SELECT AVG(Rating) FROM Fruit_Ratings WHERE FruitId = Fruits.FruitId), 0) Rating FROM Fruits");
            gvFruits.DataBind();
     }
    
    private static DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
    
    //and here is the code full functioning app for rating.[Full functioning rating app code][1]
      
    
    
      [1]: http://www.aspsnippets.com/Articles/Using-ASPNet-AJAX-Rating-Control-inside-GridView-TemplateField-ItemTemplate.aspx
