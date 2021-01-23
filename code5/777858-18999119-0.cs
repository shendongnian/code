        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 10; i++)
            {
                DropDownList1.Items.Add(i.ToString());
            }
            DropDownList1.AutoPostBack = true;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
