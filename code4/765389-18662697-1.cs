    public class TestObject
    {
        public string Q { get; set; }
        public bool C { get; set; }
        public bool R { get; set; }
        public bool E { get; set; }
    }
    public partial class Default : System.Web.UI.Page
    {
        public List<TestObject> Values { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //NEED SOME DATA TO TEST THE RESULT
                Values = new List<TestObject>();
                Values.Add(new TestObject() { Q = "test 1", C = true, E = true, R = true });
                Values.Add(new TestObject() { Q = "test 1", C = true, E = false, R = true });
                Values.Add(new TestObject() { Q = "test 1", C = true, E = true, R = false });
                Values.Add(new TestObject() { Q = "test 1", C = false, E = true, R = true });
                //BIND TO THE GRID
                SearchGrid.DataSource = Values;
                SearchGrid.DataBind();
            }
        }
        //FIRES FOR EVERY ROW IN THE GRID
        protected void SearchGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //WE ONLY CARE ABOUT THE DATAROW NOT HEADER ETC
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            //GET THE BOUND INDIVIDUAL ITEM
            TestObject obj = (TestObject)e.Row.DataItem;
            //FIND ALL THE CHECKBOXES
            CheckBox cchk = e.Row.FindControl("CCheckBox") as CheckBox;
            CheckBox echk = e.Row.FindControl("ECheckBox") as CheckBox;
            CheckBox rchk = e.Row.FindControl("RCheckBox") as CheckBox;
            //CHECK IT OR NOT BASED ON THE DATATITEMS VALUE
            if (cchk != null)
                cchk.Checked = obj.C;
            if (echk != null)
                echk.Checked = obj.E;
            if (rchk != null)
                rchk.Checked = obj.R;
        }
    }
