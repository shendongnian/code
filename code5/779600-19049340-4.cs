        .....
        DBConnection.Close();
        bool found=false;
        foreach (var item in listBox1.Items)
        {
            var entry = item.ToString();
            if (entry.Contains(returnvalue.ToString()))
            {
                listBox1.Items.Remove(item);
                listBox1.Items.Add(entry + " extra add");
                found = true;
                break;
            }
        }
        if (!found)
        {
            listBox1.Items.Add(returnvalue.ToString());
        }
        textBox1.Clear();
        .....
