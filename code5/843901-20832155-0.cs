    using (StreamWriter wwrite = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("SHIFT-JIS")))
    {
        for (int i = 0; i < 14738; ++i)
        {
            wwrite.WriteLine(i.ToString() + "|" + listView1.Items[i].SubItems[1].Text + "|" + listView1.Items[i].SubItems[2].Text + "|" + listView1.Items[i].SubItems[3].Text);
        }
    }
