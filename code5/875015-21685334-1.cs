    for (int i = listBox1.Items.Count - 1; i == 0; i--)
    {
        int item = listBox1.Items[i];
        if (listBox2.Items.Contains(item))   // notice change of reference
        {
            listBox1.Items.RemoveAt(i);
        }
    }
    
