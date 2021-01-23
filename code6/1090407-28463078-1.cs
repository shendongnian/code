        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Contains(listboxVal))
            {
                list.RemoveAt(i);
            }
        }
        listBox1.DataSource = null;
        listBox1.Items.Clear();
        listBox1.DataSource = list;
