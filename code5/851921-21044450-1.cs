    using System.Data.SqlClient;using Telerik.Web.UI;
    namespace RadTreeView_DataBindDataTable
    {    
        public partial class _Default : System.Web.UI.Page        
        {        
            protected void Page_Load(object sender, EventArgs e)                
            {                        
                if (!IsPostBack)                        
                {                               
                    BindToDataTable(RadTreeView1);                        
                }               
            }        
            private void BindToDataTable(RadTreeView treeView)           
            {                   
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.NwindConnectionString);        
                SqlDataAdapter adapter = new SqlDataAdapter("select CategoryID, CategoryName, Description from Categories", connection);            
                DataTable dataTable = new DataTable();        
                adapter.Fill(dataTable);        
                treeView.DataTextField = "CategoryName";                  
                treeView.DataFieldID = "CategoryID";                   
                treeView.DataValueField = "Description";                     
                treeView.DataSource = dataTable;                    
                treeView.DataBind();            
            }  
        }
    
    }
