    protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<Person>> data = new Dictionary<string, List<Person>>();
            data.Add("Managers", new List<Person>() { new Person() { Age = 38, Name = "Bob" }, new Person() { Age = 45, Name = "Stephen" } });
            data.Add("Developers", new List<Person>() { new Person() { Age = 25, Name = "Jake" }, new Person() { Age = 31, Name = "John" }, new Person() { Age = 27, Name = "Matthew" } });
            grid1.RowDataBound += grid1_RowDataBound;
            grid1.DataSource = data;
            grid1.DataBind();
        }
        void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                Label label = (Label)e.Row.FindControl("Label1");
                // extract list items
                string[] names = ((KeyValuePair<string, List<Person>>) e.Row.DataItem).Value.Select(x => x.Name).ToArray();
                label.Text = string.Join(",", names);
            }
        }
        protected class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
