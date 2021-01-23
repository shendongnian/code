    lsbReadingChapter.SelectedIndex = Convert.ToByte(App.Recent.AyaID);
    //First scroll to the bottom of the list
    lsbReadingChapter.ScrollIntoView(lsbReadingChapter.Items.Count - 1);
    //Update layout to avoid competition between the two ScrollIntoView() calls
    lsbReadingChapter.UpdateLayout();
    //Then scroll to the selected index
    lsbReadingChapter.ScrollUntilView(lsbReadingChapter.SelectedIndex);
    lsbReadingChapter.UpdateLayout();
