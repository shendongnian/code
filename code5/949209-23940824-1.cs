    <script runat = "server">
    
        protected void Page_Load(object sender, EventArgs e)
        {
           Button b = new Button();
           b.Text = "EDIT";
           b.ID = b.ID + "edit button";
           b.Click += Edit_Button_Click;
           form1.Controls.Add(b);
        }
    
        protected void Edit_Button_Click(object sender, EventArgs e)
        {
           Button btnSomeButton = sender as Button;
           btnSomeButton.Text = "I was clicked!";
        }
    
    </script>
