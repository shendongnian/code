        list.Items.Add(string.Format("{0,20} {1,20}","header1","header2"));
        for (int i = 0; i < column1.Count;i++)
        {
            list.Items.Add(string.Format("{0,20} {1,20}", column1[i], column2[i]));
        }
