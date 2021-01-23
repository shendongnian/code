    private void button1_Click(object sender, EventArgs e)
    {
        int value;
        if (int.TryParse(textBox1.Text, out value))
        {
            // This is from your code above. The logic does not make sense in that
            // it is doing a lot of extra work to just add 'value' to the listBox1.
            // I assume in reality you're actually adding 'myClass' to a global list?
            List<myClass> myList = new List<myClass>();
            myList.Add(new myClass { Skaitlis1 = value });
            foreach (myClass pers in myList)
            {
                listBox1.Items.Add(pers.Skaitlis1);
            }
        }
        else
        {
            MessageBox.Show("You must enter a valid integer!");
        }
    }
