    ListViewGroup group = new ListViewGroup();//move to here
    if (result.Substring(0, 7) == "|album|")
            {
                
                group.Header = result.Substring(7);
                lstPlaylist.Groups.Add(group); // lstPlaylist is existing ListView control for playlist
            }
    
            else
            {
                ListViewItem item = new ListViewItem(result, 0, group);//now group is initialized here as well
                lstPlaylist.Items.Add(item);
            }
