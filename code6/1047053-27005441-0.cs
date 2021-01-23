    public class BindableSelectedItemBehavior : Behavior<TreeView>
    {
         //Dependency property called SelectedTreeViewItem register it
    }
 
    public partial class Window1 : Window
    {
         public Window1()
         {
           DataContext = new WindowViewModel();
         }
        private void New_subject_Click(object sender, RoutedEventArgs e)
        {
        // here the code to read the instance of the class BindableSelectedItemBehavior and interact  
        // with the selectedItem when I click on the button
           var windowViewModel = DataContext as WindowViewModel;
           var selectedItem = windowViewModel.SelectedItem;
        }
    }
    public class WindowViewModel()
    {
          public object SelectedItem { get; set; } // You want to change object to the type you are expecting
    }
