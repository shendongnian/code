    for (int n = listBox1.Items.Count - 1; n >= 0; --n)
    {
        string removelistitem = "WHATEVER YOU WANT TO REMOVE";
        if (listBox1.Items[n].ToString().Contains(removelistitem))
        {
            listBox1.Items.RemoveAt(n);
        }
    }
