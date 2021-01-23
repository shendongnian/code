    dataGridView1.Rows.Add("P","1");
            dataGridView1.Rows.Add("F","2");
            int countF = 0;
            int countP = 0;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
               string a= dataGridView1[0, i].Value.ToString();
               string b = dataGridView1[1, i].Value.ToString();
               if (a == "F")
               {
                   countF= Convert.ToInt32(b);
                   countF++;
               }
               if (a == "P")
               {
                   countF = Convert.ToInt32(b);
                   countP++;
               }
                }
            if (countF > countP)
            {
                //display
            }
            else
            {
                //display
            }
