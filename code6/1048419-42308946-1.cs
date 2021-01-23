    using System;
    using System.Data;
    using System.Data.OleDb;
    namespace ProjectDemo_Asp.et
    {
        public partial class Default : System.Web.UI.Page
        {
            public string connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\bookstore.mdb;Persist Security Info=False;";
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    DataTable _objdt = new DataTable();
                    _objdt = GetDataFromDataBase("");
                    if (_objdt.Rows.Count > 0)
                    {
                        GridView1.DataSource = _objdt;
                        GridView1.DataBind();
                    }
                }
            }
    
            /// 
            /// Function for binding retribing the data from database
            /// In this i have used Access DB you can use SQL DB to bind the data
             ///
            public DataTable GetDataFromDataBase(string searchtext)
            {
                DataTable _objdt = new DataTable();
                string querystring = "";
                querystring = "select * from Books";
                if (querystring != "")
                {
                    querystring += " where title like '%" + txtsearch.Text + "%';";
                }
                OleDbConnection _objcon = new OleDbConnection(connectionstring);
                OleDbDataAdapter _objda = new OleDbDataAdapter(querystring, _objcon);
                _objcon.Open();
                _objda.Fill(_objdt);
                return _objdt;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                DataTable _objdt = new DataTable();
                _objdt = GetDataFromDataBase(txtsearch.Text);
                if (_objdt.Rows.Count > 0)
                {
                    GridView1.DataSource = _objdt;
                    GridView1.DataBind();
                }
            }
        }
    }
