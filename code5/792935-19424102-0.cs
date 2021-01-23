        private void btnAddWord_Click(object sender, EventArgs e)
        {
            //if the textbox is empty
            if (string.IsNullOrEmpty(tbxAddWord.Text))
            {
                MessageBox.Show("You have entered no characters in the textbox.");
                tbxAddWord.Focus();
            }
            else
            {
                //if the number of items in the listbox is greater than 29
                if (lbxUnsortedList.Items.Count > 29)
                {
                    MessageBox.Show("You have exceeded the maximum number of words in the list.");
                    tbxAddWord.Text = "";
                }
                //error message for entering word that is already in the list
                bool contains = false;
                for (int i = 0; i < lbxUnsortedList.Items.Count; i++)
                {
                    if (lbxUnsortedList.Items[i].ToString().ToLower() == this.tbxAddWord.Text.ToString().ToLower())
                    {
                        contains = true;
                    }
                }
                //if there is no match in the list
                if (!contains)
                {
                    //add word to the listbox
                    lbxUnsortedList.Items.Add(tbxAddWord.Text);
                    //update tbxListBoxCount
                    tbxListboxCount.Text = lbxUnsortedList.Items.Count.ToString();
                    //onclick, conduct the bubble sort
                    bool swapped;
                    string temp;
                    do
                    {
                        swapped = false;
                        for (int i = 0; i < lbxUnsortedList.Items.Count - 1; i++)
                        {
                            int result = CarNameData[i].ToString().CompareTo(CarNameData[i + 1]);
                            if (result > 0)
                            {
                                temp = CarNameData[i];
                                CarNameData[i] = CarNameData[i + 1];
                                CarNameData[i + 1] = temp;
                                swapped = true;
                            }
                        }
                    } while (swapped == true);
                    tbxAddWord.Text = "";
                }
                // if there is a match in the list
                else
                {
                    MessageBox.Show("The word that you have added is already on the list");
                    tbxAddWord.Text = "";
                    tbxAddWord.Focus();
                }
            }
        }
