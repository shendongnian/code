                if (title == "PDR")
                {
                    Items = new List<IFormItem>();
                    for (int i = 1; i < line.Length; i++)
                    {
                        string[] pty = line[i].Split('\t');
                        FormItem fi = new FormItem();
                        Items.Add(fi);
                        fi.Type = (ItemTypes)Enum.Parse(typeof(ItemTypes), pty[1]);
                        fi.Id = Convert.ToInt32(pty[0]);
                        fi.X = int.Parse(pty[2]);
                        fi.Y = Convert.ToInt32(pty[3]);
                        fi.Height = Convert.ToInt32(pty[4]);
                        fi.Width = Convert.ToInt32(pty[5]);
                        fi.Text = pty[6].ToLower();
                    }
                }
