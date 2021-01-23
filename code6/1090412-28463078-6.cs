        for (int i = list.Count - 1; i > 0;  i--)
        {
            if (list[i].s.Contains(listboxVal))
            {
                list.RemoveAt(i); 
            }
        }       
        listBox1.DataSource = null;
        listBox1.Items.Clear();
        listBox1.DataSource = list;
