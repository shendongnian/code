    private void tbSearchRun()
        {
            TextBox textbox = tbSearch as TextBox;
            if (textbox != null)
            {
                _searchstr = textbox.Text;
                if (_searchstr == null) return;
                ICollectionView view = CollectionViewSource.GetDefaultView(SentenceLists);
                view.Filter = new Predicate<object>(FilterBySearch);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("sortWord", ListSortDirection.Ascending));
                view.Refresh();
            }
        }
    private bool FilterBySearch(object item)
        {
            ServiceTemplateController.SentenceList sl = item as ServiceTemplateController.SentenceList;
            if (_searchstr.ToUpper() == "") return true;
            if (sl.sentence.Contains(_searchstr.ToUpper()))
            {
                string[] strArray = sl.sentence.Split(' ');
                for (int i = 0; i < strArray.Count(); i++)
                {
                    if (strArray[i].Contains(_searchstr.ToUpper()))
                    {
                        if (radioBefore.IsChecked == true)
                        {
                            if (i == 0) sl.sortWord = strArray[i];
                            else sl.sortWord = strArray[i - 1];
                        }
                        else  //radio after is selected then.
                        {
                            if (i == strArray.Count() - 1) sl.sortWord = strArray[i];
                            else sl.sortWord = strArray[i + 1];
                        }
                        break;
                    }
                }
                return true;
            }
            return false;
        }
