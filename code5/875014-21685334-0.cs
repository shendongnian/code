    foreach (int item in listBox1.Items)
    {
        if (listBox2.Items.Contains(item))   // notice change of reference
        {
            listBox1.Items.Remove(item);
        }
    }
