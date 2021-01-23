    public static class ExtensionMethods
    {
       public static int RemoveAll<T>(
          this ObservableCollection<T> coll, Func<T, bool> condition)
     {
          var itemsToRemove = coll.Where(condition).ToList();
          foreach (var itemToRemove in itemsToRemove)
          {
              coll.Remove(itemToRemove);
          }
          return itemsToRemove.Count;
     }
    }  
    ocChoicesinItem.RemoveAll(x => temp.ItemsInInvoiceChoices.Any(y => y.ChoicesId == x.ChoicesId);
