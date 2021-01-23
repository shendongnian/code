    public partial class _default : System.Web.UI.Page
        {
     List<ListBox> myList;
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
            myList = new List<ListBox>();
           Button1.Click += Add_ListBox1;
        }
    
        public void Add_ListBox1(object sender, EventArgs e)
        {
            int count = 1;
            
    
            if (ViewState["Clicks"] != null)
            {
                count = (int)ViewState["Clicks"] + 1;
    
                ListBox temp_listBox = new ListBox();
                myList.Add(temp_listBox);
                Panel1.Controls.Add(temp_listBox);
               
            }
    
    
            ViewState["Clicks"] = count;
    
           
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
    
            Add_ListBox1(e,e);
        }
    }
