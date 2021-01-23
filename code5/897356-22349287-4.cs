    private void Form1_Load(object sender, EventArgs e)
    {
        foreach(var item in ComboBox1.Items)
        {
           if(item.ToString().Contains("*"))
           {
               //Modify item color here
           }
        }
    }
