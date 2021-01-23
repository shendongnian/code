    using (StreamReader reader = File.OpenText("playlist.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    result = reader.ReadLine();
                    ListViewGroup group = null;
                    if (result.Substring(0, 7) == "|album|")
                    {
                        group = new ListViewGroup();
                        group.Header = result.Substring(7);
                        lstPlaylist.Groups.Add(group); // lstPlaylist is existing ListView control for playlist
                    }
                    else
                    {
                        if (group != null)
                        {
                            ListViewItem item = new ListViewItem(result, 0, group);
                            lstPlaylist.Items.Add(item);
                        } 
                        else
                        {
                            // you are trying to add a track before any group has been created.
                            // handle this error condition
                        }
                    }
                }
            }
