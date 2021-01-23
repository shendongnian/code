    public partial class WebForm1 : System.Web.UI.Page
    {
        private bool ShowButton2()
        {
            return ViewState["createButton"] == null ? false : (bool)ViewState["createButton"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ShowButton2())
                CreateButton();
        }
        void CreateButton()
        {
            Button Button2 = new Button();
            Button2.Text = "Add";
            Button2.ID = "button2";
            Button2.Click += Button2_Click;
            PostBackTrigger pTrigger = new System.Web.UI.PostBackTrigger() { ControlID = Button2.ID };
            updatePanel1.Triggers.Add(pTrigger);
            DIV2.Controls.Add(Button2);
        }
        void Button2_Click(object sender, EventArgs e)
        {
            
        }
        protected void button1_Click(object sender, EventArgs e)
        {
            if (!ShowButton2())
            {
                ViewState["createButton"] = true;
                CreateButton();
            }
        }
    }
