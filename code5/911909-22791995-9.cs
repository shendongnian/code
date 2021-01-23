    private void button3_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < listOfLists.Count; i++)
        {
            var list = (SortedList) listOfLists.GetByIndex(i);
            for (int j = 0; j < list.Count; j++)
            {
                var key = (string) list.GetKey(j);
                var value = (string) list.GetByIndex(j);
            }
        }
    }
