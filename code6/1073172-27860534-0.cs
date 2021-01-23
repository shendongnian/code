    int m=0;
            foreach (string f in Folder1FileNames)
            {
                while (f != Folder2FileNames[m] && m < Folder2FileNames.Length)
                {
                    m++;
                    if (m == Folder2FileNames.Length)
                    {
                        Label newlabe = new Label();
                        newlabe.Text = f;
                        if(!listBox1.Items.Contains(newlabe.Text))
                        {
                            listBox1.Items.Add(newlabe.Text);
                        }
                    }
                }
                m = 0;
            }
