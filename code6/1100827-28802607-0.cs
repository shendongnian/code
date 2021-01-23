    for (int x = 0; x < listBox1.Items.Count; x++)
    {
        DateTime z = DateTime.Parse(listBox2.Items[i].ToString());
        DateTime c = DateTime.Parse(listBox3.Items[i].ToString());
        TimeSpan w = c.Subtract(z);
    } 
