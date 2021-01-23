            for (int x = 0; x < listBox2.Items.Count; x++)
            {
                if (listBox2.Items[x].ToString() == check[x])
                {
                    listBox3.Items.Add(x+ " Correct ");
                }
                else
                {
                    listBox3.Items.Add(x + " Error ");
                }
            }
        }
