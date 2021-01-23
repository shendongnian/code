    foreach (ListViewGroup grp in listFiles.Groups)
        {
          bool FirstItem = false;
            foreach (ListViewItem item in grp.Items)
            {
                if (!FirstItem)
                {
                    item.Checked = false;
                    FirstItem = true;
                }
                else
                {
                    item.Checked = true;
                }
            }
        }
