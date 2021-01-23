    public class MyListView : ListView
    {
      public UserControl uc { get; set; }
      internal MyLEvent<Type,Type> MyLEvnt  { get; set; }
      public MyListView()
      {
        PreviewKeyDown += new KeyEventHandler(MyListView_PreviewKeyDown);
      }
      private void MyListView_PreviewKeyDown(object sender,KeyEventArgs e)
      {
         ListView view = sender as ListView;
         var item = view.SelectedItem;
        if (item != null)
        {
            string str = item.GetType().Name;
            if (e.Key == Key.Delete)
            {
                MyLEvnt.Method(item, "Delete");
            }
            else if (e.Key == Key.Enter)
            {
                MyLEvnt.Method(item, "Modify");
                uc.GetType().GetProperty("Update").SetValue(uc, 1, null);
                MethodInfo mi = uc.GetType().GetMethod("IClear");
                mi.Invoke(uc, null);
            }
        }
     }
