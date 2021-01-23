     Table t = new Table();
                   foreach(var album in data)
                        {
                            TableRow tr = new TableRow();
                
                            tr.Cells.Add(new TableCell() { Text = album.AlbumName });        
                            HyperLink link = new HyperLink![enter image description here][2]();
                            link.ID = "HyperLink1";
                            link.NavigateUrl = "~/files/aspx_pages/.aspx";//Give the name of the aspx page that you want to navigate
                            link.Text = "Album1 Link";
                            TableCell tc = new TableCell();
                            tc.Controls.Add(link);
                            //tc.Text="link";
                            tr.Cells.Add(tc);
                            t.Rows.Add(tr);
                        }
            Page.Controls.Add(t);
