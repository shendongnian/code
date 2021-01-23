     public class MyListView : ListView
    {
        public UserControl uc { get; set; }
        public object ML { get; set; }
        public MyListView()
        {
            PreviewKeyDown += new KeyEventHandler(MyListView_PreviewKeyDown);
        }
        public void Methode<T,M>() where T : class where M : class
        {
            ListViewEvents<T, M> mn = new ListViewEvents<T, M>();
            ML = mn;
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
                    MethodInfo mi = ML.GetType().GetMethod("Method");
                    mi.Invoke(ML,new[]{item,"Delete"});
                    MethodInfo m = uc.GetType().GetMethod("IClear");
                    m.Invoke(uc, null);
                }
                else if (e.Key == Key.Enter)
                {
                    MethodInfo m = ML.GetType().GetMethod("Method");
                    object ob = m.Invoke(ML, new[] { item, "Modify" });
                    PropertyClass.Properties(uc, ob, 'U');
                }
            }
        }
    }
