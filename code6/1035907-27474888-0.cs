        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
                List<string> myList = new List<string>();
                foreach (string myString in PreviouslyDefinedStringArray)
                {
                    if (myString.Contains(sender.Text) == true)
                    {
                        myList.Add(myString);
                    }
                }
                sender.ItemsSource = myList;
        }
