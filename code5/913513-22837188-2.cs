    public partial class aaaa : System.Web.UI.Page
    {
    
        public List<Employee> lstEmployee
        {
            get
            {
                if (Session["lstEmployee"] != null)
                {
                    return (List<Employee>)Session["lstEmployee"];
                }
                else
                {
                    return new List<Employee>();
                }
            }
            set
            {
                Session["lstEmployee"] = value;
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Employee> list = new List<Employee>();
    
                Employee obj = new Employee();
                obj.ID = 1;
                obj.Name = "Name1";
                obj.UniqueID = Guid.NewGuid();
                list.Add(obj);
    
                obj = new Employee();
                obj.ID = 2;
                obj.Name = "Name2";
                obj.UniqueID = Guid.NewGuid();
                list.Add(obj);
    
                lstEmployee = list;
            }
        }
    
        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = lstEmployee;
        }
    
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                saveAllData();
                lstEmployee.Insert(0, new Employee() { UniqueID = Guid.NewGuid() });
                e.Canceled = true;
                RadGrid1.Rebind();
            }
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            saveAllData();
        }
    
        protected void saveAllData()
        {
            //Update Session
            foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
            {
                Guid UniqueID = new Guid(item.GetDataKeyValue("UniqueID").ToString());
                Employee emp = lstEmployee.Where(i => i.UniqueID == UniqueID).First();
                emp.Name = (item.FindControl("TextBox1") as TextBox).Text;
            }
        }
    
    }
    
    public class Employee
    {
        public Guid UniqueID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int weeknumber { get; set; }
    }
