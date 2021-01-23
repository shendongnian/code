    private void button1_Click(object sender, EventArgs e)
    {
        string[] arr = new string[listBox1.Items.Count];
        listBox1.Items.CopyTo(arr, 0);
        var arr2 = arr.Distinct();
        listBox1.Items.Clear();
        foreach (string s in arr2)
        {
            listBox1.Items.Add(s);
        }
    }
