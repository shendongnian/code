    public partial class second_page : PhoneApplicationPage
    {
      public second_page()
      {
         InitializeComponent();
         phoneLLS.DataContext = MainPage.collection;
         addBtn.Click += addBtn_Click;
         delBtn.Click += delBtn_Click;
         showBtn.Click += showBtn_Click;
      }
      private void addBtn_Click(object sender, RoutedEventArgs e)
      {
         MainPage.collection.Add("element");
      }
      private void delBtn_Click(object sender, RoutedEventArgs e)
      {
         MainPage.collection.RemoveAt(MainPage.collection.Count - 1);
      }
      private void showBtn_Click(object sender, RoutedEventArgs e)
      {
         List<TextBlock> controlList = new List<TextBlock>();
         SearchForControls<TextBlock>(phoneLLS, ref controlList);
      }
      private static void SearchForControls<T>(DependencyObject parent, ref List<T> controlList) where T : DependencyObject
      {
         int numberOfChildreen = VisualTreeHelper.GetChildrenCount(parent);
         for (int i = 0; i < numberOfChildreen; i++)
         {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
               controlList.Add((T)child);
            else SearchForControls<T>(child, ref controlList);
         }
      }
    }
 
   
