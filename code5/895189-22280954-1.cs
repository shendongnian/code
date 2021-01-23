    using System.Windows;
    using System.Windows.Controls;
    namespace SOWPF
    {
	    /// <summary>
	    /// Interaction logic for MainWindow.xaml
	    /// </summary>
	    public partial class MainWindow : Window
	    {
		    public MainWindow()
		    {
			    InitializeComponent();
			    var friendViewModel = new FriendViewModel();
			    friendViewModel.AddFriends();
			    this.DataContext = friendViewModel;
		    }
		    private void Button_Click(object sender, RoutedEventArgs e)
		    {
			    var parent = (StackPanel)((sender as Button).Parent);
			    var children = parent.Children;
			    foreach(var child in children)
			    {
				    if (child.GetType().Equals(typeof(TextBox)))
				    {
					    var tb = child as TextBox;
					    tb.Focus();
					    tb.SelectAll();
					    break;
				    }
			    }
		    }
	    }
    }
