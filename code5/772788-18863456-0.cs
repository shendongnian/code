    for (int y = 0; y < var.Length; y++)
                {
                    for (int x = 0; x < d.Length; x++)
                    {
                        if (d[x].Substring(0, 0).ToUpper() == var.Substring(len, len).ToUpper())
                        {
                            textBox1.Text = textBox1.Text + "\n" + d[x];
                            len = len + 1;
                        }
                    }
                }
