    //hold already selected items. Last item will be last selected
        List<int> alreadySelectedIndexes = new List<int>();
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrackSelection((ListBox)sender, alreadySelectedIndexes);
            bool allowSelection = false;
            int currentSelectedIndex = -1;
            //make sure we have an item selected
            if (!listBox1.SelectedIndex.Equals(-1))
            {
                //if first selection we allow it
                if (alreadySelectedIndexes.Count.Equals(1))
                {
                    allowSelection = true;
                }
                else
                {
                    //get the last item index that was selected from our list
                    currentSelectedIndex = alreadySelectedIndexes[alreadySelectedIndexes.Count - 1];
                    //make sure we have a previous index item
                    if ((currentSelectedIndex - 1) >= 0)
                    {
                        //check if previous item before currently selected is checked
                        if (listBox1.GetSelected(currentSelectedIndex - 1))
                        {
                            allowSelection = true;
                        }
                    }
                    //make sure we have a next index item
                    if ((currentSelectedIndex + 1 ) <= listBox1.Items.Count - 1)
                    {
                        //check if next item after currently selected is checked
                        if (listBox1.GetSelected(currentSelectedIndex + 1))
                        {
                            allowSelection = true;
                        }
                    }
                }
            }
            //unselect item because it wasn't before or after an already selected item
            if (!allowSelection && !currentSelectedIndex.Equals(-1))
            {
                listBox1.SetSelected(currentSelectedIndex, false);
            }
        }
        private void TrackSelection(ListBox listBox, List<int> alreadySelectedList)
        {
            ListBox.SelectedIndexCollection indexCollection = listBox.SelectedIndices;
            foreach (int index in indexCollection)
            {
                if (!alreadySelectedList.Contains(index))
                {
                    alreadySelectedList.Add(index);
                }
            }
            foreach (int index in new List<int>(alreadySelectedList))
            {
                if (!indexCollection.Contains(index))
                {
                    alreadySelectedList.Remove(index);
                }
            }
        }
