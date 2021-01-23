            if (t1.Text != "")
            {
                Name.Add(t1.Text);
                l1.Items.Clear(); //add this statement
                for (int i = 0; i < Name.Count; i++)
                {
                    l1.Items.Add(Name[i]);
                }
                if (Name.Count > 5)
                    ListItemAdded(Name);
            } 
