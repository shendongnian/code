    class test
    {
        public void read()
        {
           int a = 0;
           if(Int32.TryParse(textbox1.Text, out a))
           {
               // a is the integer from the textbox
           }
           else
           {
               MessageBox.Show("The textbox does not contain a number!");
           }
        }
    }
