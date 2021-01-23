       Button_click()
       {
            DateTime MyDateTime = new DateTime();
            MyDateTime = DateTime.ParseExact(textBox1.Text, "MM/dd/yyyy", null);
            textBox2.Text = MyDateTime.ToString("dd/MM/yyyy");
       }
