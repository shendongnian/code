        for (int i = 0; i <= 90; i++)
        {
            ...
            listBox2.Items.Add(x);
            listBox1.Items.Add(y);
            listBox3.Items.Add(z);
        }
        ...
        foreach (var item in listBox1.Items)
        {
            SaveFile.WriteLine(item);
        }
        foreach (var a in listBox2.Items)
        {
            SaveFile.WriteLine(a);
        }
