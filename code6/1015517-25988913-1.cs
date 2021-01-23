    List<Test> tests = new List<Test>();
            tests.Add(new Test { Id = 1, Name = "Name 1" });
            tests.Add(new Test { Id = 2, Name = "Name 2" });
            tests.Add(new Test { Id = 3, Name = "Name 3" });
            tests.Add(new Test { Id = 4, Name = "Name 4" });
            AddItem(tests, typeof(Test), "Id", "Name", "< Select Option >");
            comboBox1.DataSource = tests;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
