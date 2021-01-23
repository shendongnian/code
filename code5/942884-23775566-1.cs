        private void MyListView_SelectionChanged(object param)
        {
            IList selectedItems = (IList)param;
            List<MyViewModel> myList = selectedItems.OfType<MyViewModel>().ToList();
            if (myList.Count > 0)
            {
                myList.Sort(); // Implement comparator on MyViewModel
		        LatestSelectedItem = myList[myList.Count-1];
            }
        }
