    private void button1_Click_2(object sender, EventArgs e)
            {
            Student s = new Student
                {
                    FirstName = "Svetlana",
                    LastName = "Omelchenko",
                    Password = "hh",
                    modules = new string[] { "001", "002", "003", "004" }
                };
            SomeMethod(s);
            Console.WriteLine(s.FirstName); //will output Svetlana
            
        }
        private void SomeMethod(Student s)
        {
            s = new Student();
            s.FirstName = "New instance";
        }
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string[] modules { get; set; }
        }
