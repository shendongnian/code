        public void addItem()
        {
            item i = new item(myItems.Count + 1);
            myItems.Add(i);
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.DataBoundItem == i)
                {
                    dr.Selected = true;
                }
            }
        }
