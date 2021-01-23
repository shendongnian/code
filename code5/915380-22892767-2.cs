            int[] indices = listBoxFrom.GetSelectedIndices();
            for (int i = indices.Length - 1; i >= 0; i--)
            {
                ListItem LI = listBoxFrom.Items[indices[i]];
                listBoxTo.Items.Add(LI);
                listBoxFrom.Items.RemoveAt(indices[i]);
            }
 
