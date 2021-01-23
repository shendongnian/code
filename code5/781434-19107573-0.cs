                      if (f.Text != iRow["Sender"].ToString())
                        {
                            if (!people.Contains(iRow["Sender"].ToString()))
                            {
                                people.Add(iRow["Sender"].ToString());
                            }
                        }
