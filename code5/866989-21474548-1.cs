    lsbReadingChapter.SelectedIndex = Convert.ToByte(App.Recent.AyaID);
    //First scroll to the bottom of the list
    lsbReadingChapter.ScrollIntoView(lsbReadingChapter.Items[lsbReadingChapter.Items.Count - 1]);
    lsbReadingChapter.UpdateLayout();
    //Then scroll to the selected index
    lsbReadingChapter.ScrollIntoView(lsbReadingChapter.SelectedItem);
    lsbReadingChapter.UpdateLayout();
