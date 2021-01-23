             int seatnum = int.Parse(textBox1.Text);
             Seat = new int[15];
            if (textBox1.Text != "")
            {
                Seat[seatnum - 1] = seatnum;
                listBox1.Items.Add(seatnum);
            }
