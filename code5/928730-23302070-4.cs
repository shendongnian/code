    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Web.Configuration;
    
    namespace ExampleCheckbox
    {
    public partial class Question_One : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    
            SqlConnection con = new SqlConnection(connectionString);
    
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * from Questions";
    
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataSet questionsDataSet = new DataSet();
    
    
                con.Open();
                dataAdapter.Fill(questionsDataSet, "Question");
    
                DataTable dt = questionsDataSet.Tables["Question"];
    
    			int i = 0;
    			string str1 = string.Empty;
			int i = 0;
                        dr = dt.Rows(ClientID);   //whatever you're using for the row index
				foreach (DataColumn dc in dt.Columns)
				{
					ListItem newItem = new ListItem(dr[dc].ToString(), i.ToString());
					CheckBoxList1.Items.Add(newItem);
					i++;
				}
			}
		} 
    		} 
    }
