    private static void MoveSelectedItems(ListBox source, ListBox target) {
      if (null == source)
        throw new ArgumentNullException("source");
      else if (null == target)
        throw new ArgumentNullException("target");
    
      // Indice to move (Linq)
      var indice = source.SelectedIndices.OfType<int>().OrderByDescending(item => item);
      // Place to move (at the end of target listbox, if target is not sorted)
      int place = target.Items.Count;
      // we don't need repaint source as well as target on moving each item
      // which cause blinking, so let's stop updating them for the entire operation
      source.BeginUpdate();
      target.BeginUpdate();
      Boolean sorted = target.Sorted;
    
      try {
        // switch sorting off so sorting would not change indice 
        // of items inserted
        target.Sorted = false;
    
        // Move items from source to target
        foreach (var index in indice) {
          target.Items.Insert(place, source.Items[index]);
          target.SelectedIndices.Add(place);
          
          source.Items.RemoveAt(index);
        }
      }
      finally {
        target.Sorted = true;
        target.EndUpdate();
        source.EndUpdate();
      }
    }  
