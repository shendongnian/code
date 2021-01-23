    //Use this ListBox extension for convenience
    public static class ListBoxExtension {
       public static void SetSelectedWithoutJumping(this ListBox lb, int index, bool selected){
         int i = lb.TopIndex;
         lb.SetSelected(index, selected);
         lb.TopIndex = i;
       }
    }
    //Then just use like this
    yourListBox.SetSelectedWithoutJumping(index, true);
