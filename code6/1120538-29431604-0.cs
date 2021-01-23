        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dictionary<string, string> personsList = new Dictionary<string, string>();
                personsList.Add("Andersson", "Person1");
                personsList.Add("Smith", "Person2");
                personsList.Add("Name 3", "Person3");
                personsList.Add("Name 4", "Person4");
                personsList.Add("Name 5", "Person5");
                ListBoxPersons.DataTextField = "Value";
                ListBoxPersons.DataValueField = "Key";
                ListBoxPersons.DataSource = personsList;
                ListBoxPersons.DataBind();
            }
        }
        protected void ListBoxPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = ListBoxPersons.SelectedValue;
        }
