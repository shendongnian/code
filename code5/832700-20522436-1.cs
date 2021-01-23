        IList<Person> _allPersons;
        protected void Page_Init(object sender, EventArgs e)
        {
            _allPersons = Helper.GetPersons();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv.DataSource = _allPersons;
                gv.DataBind();
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            var selectedPersons = GetSelectedPersons();
            lblOutput.Text = string.Join(",", selectedPersons.Select(x => string.Format("{0} {1}", x.FirstName, x.LastName)));
        }
        private IList<Person> GetSelectedPersons()
        {
            var persons = new List<Person>();
            foreach (GridViewRow row in gv.Rows)
            {
                var chkSelect = row.FindControl("chkSelect") as CheckBox;
                var dataKey = row.FindControl("dataKey") as HiddenField;
                if (chkSelect != null && dataKey != null && chkSelect.Checked)
                {
                    var person = _allPersons.FirstOrDefault(x => x.FirstName == dataKey.Value);
                    if (person != null)
                        persons.Add(person);
                }
            }
            return persons;
        }
