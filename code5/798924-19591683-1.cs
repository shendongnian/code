      /// <summary>
      /// Interaction logic for CatItem.xaml
      /// </summary>
      public partial class CatItem : UserControl
      {
        public CatItem()
        {
          InitializeComponent();     
        }
    
        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
          if (DeleteClick != null)
            DeleteClick(sender, e);
        }
    
        public event RoutedEventHandler DeleteClick;
    
    
      }
