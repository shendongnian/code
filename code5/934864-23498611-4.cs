            //hold already selected items. Last item will be last selected
        List<int> alreadySelectedIndexes = new List<int>();
        //used to skip listBox1_SelectedIndexChanged on TrackSelection
        bool ignoreSelectedChanged = false;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prevent overflow of caused by TrackSelection
            if (!ignoreSelectedChanged)
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
                        if ((alreadySelectedIndexes.Count - 1) >= 0)
                        {
                            currentSelectedIndex = alreadySelectedIndexes[alreadySelectedIndexes.Count - 1];
                            //make sure we stay in array range
                            if ((currentSelectedIndex - 1) >= 0)
                            {
                                //check if previous item before currently selected is checked
                                if (listBox1.GetSelected(currentSelectedIndex - 1))
                                {
                                    allowSelection = true;
                                }
                            }
                            //make sure we stay in array range
                            if ((currentSelectedIndex + 1) <= listBox1.Items.Count - 1)
                            {
                                //check if next item after currently selected is checked
                                if (listBox1.GetSelected(currentSelectedIndex + 1))
                                {
                                    allowSelection = true;
                                }
                            }
                        }
                    }
                    bool isSelected = false;
                    if (currentSelectedIndex >= 0)
                    {
                        isSelected = listBox1.GetSelected(currentSelectedIndex);
                        if (!isSelected)
                        {
                            //we can remove it from the list now
                            alreadySelectedIndexes.Remove(currentSelectedIndex);
                            //reselect it if in the middle of already selected items
                            if (alreadySelectedIndexes.Contains(currentSelectedIndex + 1) && alreadySelectedIndexes.Contains(currentSelectedIndex - 1))
                            {
                                ignoreSelectedChanged = true;
                                allowSelection = true;
                                listBox1.SetSelected(currentSelectedIndex, true);
                            }
                        }
                    }
                }
                if (!currentSelectedIndex.Equals(-1) && !allowSelection)
                {
                    ignoreSelectedChanged = true;
                    listBox1.SetSelected(currentSelectedIndex, false);
                }
                //unselect item because it wasn't before or after the last selected item
            }
            ignoreSelectedChanged = false;
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
                    //remove first index in list
                    alreadySelectedList.Remove(index);
                    //add index back to end of list so we know what was deselected
                    alreadySelectedList.Add(index);
                }
            }
        }
