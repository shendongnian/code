    protected dynamic getNewObject(String name, String phone, String email)
        {
            
            // ... //I can not add the variables that received by the object parameter here.
            dynamic ex = new ExpandoObject();
            ex.Name = name;
            ex.Phone = phone;
            ex.Email = email;
            return ex;
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            var ye = getNewObject("1", "2", "3");
            Console.WriteLine(string.Format("Name = {0},Phone = {1},Email={2}", ye.Name, ye.Phone, ye.Email));
        }
