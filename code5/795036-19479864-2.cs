     public static class ListBoxExtension {
       public static void SetMultiSelectedWithoutJumping(this ListBox lb, IEnumerable<int> indices, bool selected){
         int i = lb.TopIndex;
         lb.BeginUpdate();
         foreach(var index in indices)
            lb.SetSelected(index, selected);
         lb.TopIndex = i;
         lb.EndUpdate();
       }
    }   
    //usage
    yourListBox.SetMultiSelectedWithoutJumping(new List<int>{2,3,4}, true);
