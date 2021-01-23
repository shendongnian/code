    while(reader.ReadLine())
                {
                    if (index == 0)
                    {
                        c1 = reader[index].ToString();
                        radioButton1.Text = c1;
                    }
                    if (index == 1)
                    {
                        c1 = reader[index].ToString();
                        radioButton2.Text = c1;
                    }
                    if (index == 2)
                    {
                        c1 = reader[index].ToString();
                        radioButton3.Text = c1;
                    }
                    if (index == 3)
                    {
                        c1 = reader[index].ToString();
                        radioButton4.Text = c1;
                    }
                    if (index == 4)
                    {
                        c1 = reader[index].ToString();
                        radioButton4.Text = c1;
                    }
                    if (index == 5)
                    {
                        c1 = reader[index].ToString();
                        radioButton5.Text = c1;
                    }
                    MessageBox.Show("c1  :" + c1);
                    index++;
                }
