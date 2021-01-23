    public partial class ADOTEST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindEmpData();  
            }
        }
        void BindEmpData()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=(local); Database=TestDb ; Uid=sa ; password=123 "))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select *From EMPLOYEE", cn))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "EMPLOYEE");
                }
            }
            Repeater1.DataSource = ds.Tables["EMPLOYEE"];
            Repeater1.DataBind();
        }
    }
