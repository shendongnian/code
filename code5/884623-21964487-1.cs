         if (t1.Text != "")
            {
                Name.Add(t1.Text);
                l1.Items.Add(t1.Text);
                if (Name.Count > 5)
                    ListItemAdded(Name);
            } 
