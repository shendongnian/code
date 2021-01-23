    void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
         ComboBox c = sender as ComboBox;
         //in the next line i put the name Products you put
         //the name of your list(as declared in your Bill class).
         double result = ((Bill)c.SelectedValue).Products.Sum(p => p.Price);
         //here i decided to put the sum in a textbox
         //you can put the result where you need.
         textBox1.Text = result.ToString();
    }
