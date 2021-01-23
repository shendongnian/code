     string[] values = t1.Text.Split('#');
            if (values.Length >= 5)
            {
                t2.Text = values[0];
                t3.Text = values[1];
                t4.Text = values[2];
                t5.Text = values[3];
                t6.Text = values[4];
                //change the destination
                 if (values.Length == 5)
                    t1.Text = t1.Text.Substring(9);
                else if (values.Length > 5)
                    t1.Text = t1.Text.Substring(10);
            }
