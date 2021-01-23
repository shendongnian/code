    var path = @"---"; //Path to your settings file.
            RichTextBox rtb = new RichTextBox();
            System.IO.StreamReader sis = new System.IO.StreamReader(path);
            rtb.Text = sis.ReadToEnd();
            sis.Close();
            int counter = 0;
            foreach (string line in rtb.Lines)
            {
                if (line.Contains("(") == true && line.Contains(")") == true)
                {
                    counter++;
                    string numbers = line.Substring(line.IndexOf("("), line.IndexOf(")") - (line.IndexOf("(") - 1));
                    switch (counter)
                    {
                        case 1:
                            textBox1.Text = numbers;
                            break;
                        case 2:
                            textBox2.Text = numbers;
                            break;
                        case 3:
                            textBox3.Text = numbers;
                            break;
                        case 4:
                            textBox4.Text = numbers;
                            break;
                        case 5:
                            textBox5.Text = numbers;
                            break;
                    }
                }
            }
