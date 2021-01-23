     int m = 0;
                foreach (string f in Folder1FileNames)
                {
                    m = 0;
                    while (f != Folder2FileNames[m] && m < Folder2FileNames.Length-1)
                    {
                        m++;
                        if (m == Folder2FileNames.Length-1)
                        {
                            if (Folder2FileNames[m] != f)
                            {
                                Label newlabe = new Label();
                                newlabe.Text = f;
                                if (!listBox1.Items.Contains(newlabe.Text))
                                {
                                    listBox1.Items.Add(newlabe.Text);
                                }
                            }
                            
                            
                        }
                    }
                  
                }
