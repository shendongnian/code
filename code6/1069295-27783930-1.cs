    ObservableCollection<string> MyList = new ObservableCollection<string>();
    string DraggedString;
    TextBlock DraggedOverTextBlock;
    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MyList.Add("1");
            MyList.Add("2");
            MyList.Add("3");
            MyList.Add("4");
            MyList.Add("5");
            MyList.Add("6");
            MyList.Add("7");
            MyList.Add("8");
            MyList.Add("9");
            MyList.Add("10");
            MyListView.ItemsSource = MyList;
        }
        private void MyListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            DraggedString = e.Items[0] as String;
        }
        private void MyListView_Drop(object sender, DragEventArgs e)
        {
            if (DraggedString == null || DraggedOverTextBlock == null) return;
            var indexes = new List<int> { MyList.IndexOf(DraggedString), MyList.IndexOf(DraggedOverTextBlock.Text) };
            if (indexes[0] == indexes[1]) return;
            indexes.Sort();
            var values = new List<string> { MyList[indexes[0]], MyList[indexes[1]] };
            MyList.RemoveAt(indexes[1]);
            MyList.RemoveAt(indexes[0]);
            MyList.Insert(indexes[0], values[1]);
            MyList.Insert(indexes[1], values[0]);
            DraggedString = null;
            DraggedOverTextBlock = null; 
        }
        private void TextBlock_DragOver(object sender, DragEventArgs e)
        {
            DraggedOverTextBlock = sender as TextBlock;
        }
