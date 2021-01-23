        void newButton_Click(object sender, EventArgs e)
        {
            int start = Convert.ToInt16(((Button)sender).Name.Substring(6));
            Color c1;
            for (int i = 0; i < 100; i++)
            {
                Button nextButton = flowLayoutPanel1.Controls["DynBtn" + i] as Button;
                if (i < start)
                    c1 = SystemColors.Control;
                else if (i % 2 == 0)
                    c1 = Color.Green;
                else
                    c1 = Color.Red;
                nextButton.BackColor = c1;
            }
        }
