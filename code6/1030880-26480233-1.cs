     private void button1_Click(object sender, EventArgs e)
            {
        
                   double dbVlaue = Convert.ToDouble(textBox1.Text);
                    int quot;
                    int num;
                    num = Convert.ToInt32(dbVlaue);
        
                    string rem = string.Empty;
                    while (num > 1)
                    {
                        quot = num / 2;
                        rem += (num % 2).ToString();
                        num = quot;
                    }
                    string bin = " ";
                    for (int i = rem.Length - 1; i >= 0; i--)
                    {
                        bin = bin + rem[i];
                    }
                    textBox1.Text = bin.ToString();
        
        }
