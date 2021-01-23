              int seatnum = int.Parse(textBox1.Text);
             Seat = new int[15];
            if (textBox1.Text != "")
            {
                Seat[seatnum - 1] = seatnum;
            }
            for (int i = 0; i < 15; i++)
            {
                if (Seat[i] != 0)
                {
                    listBox1.Items.Add(textBox1.Text);
                }
            }
