    static bool DrpDown1;
        static bool DrpDown2;
        static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DrpDown1 = false;
                DrpDown2 = false;
            }
        }
               
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DrpDown1)
            {
                i += 2;
                Label1.Text = "hello" + i;
                DrpDown1 = true;
            }
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DrpDown2)
            {
                i += 2;
                Label1.Text = "hello" + i;
                DrpDown2 = true;
            }
        }
