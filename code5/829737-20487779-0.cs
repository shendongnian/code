        private void button1_Click(object sender, EventArgs e)
        {
            List<MyClass> li = (List<MyClass>)Mydgv.DataSource;
            MyClass O = new MyClass();
            O.Name = "XYZ";
            O.LastName = "G";
            O.Id = new Random().Next(10, 100);
            li.Add(O);
            Mydgv.DataSource = li.ToList<MyClass>();
        }
