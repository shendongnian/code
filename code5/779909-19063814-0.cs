                        TextBlock tbl = new TextBlock();
                        tbl.Text = "Date : " + col.Value;
                        tbl.Height = 50;
                        tbl.Margin = new Thickness(35, 0, 0, 0);
                        tbl.TextWrapping = TextWrapping.Wrap;
                        tbl.TextAlignment = TextAlignment.Left;
                        LsUtsav.Foreground = new SolidColorBrush(Color.FromArgb(255, 131, 72, 7));
                        Mylist.Items.Add(tbl);
