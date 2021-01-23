                {
                    "New",
                    mi =>
                        (s, e) =>
                        {
                            MessageBox.Show("New File Created.");
                            MessageBox.Show(
                                String.Format("You clicked the {0} menu.", mi.Name));
                        }
                },
