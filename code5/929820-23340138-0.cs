    for (int i = 0; i < rows; i++)
    {
        list.Items.Add(new ListViewItem(new string[] { fname[i], lname[i], uname[i],
            accesslist[0 + (i * 31)], accesslist[1 + (i * 31)], ... , accesslist[30 + (i * 31)] }));   
    }
