    <UserControl x:Class="WpfUserControlsBindingListeningNotMuchHere.UserControl1"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 x:Name="root">
        <ListBox ItemsSource="{Binding Items, ElementName=root}"
                 SelectedItem="{Binding Selected, ElementName=root}" />
    </UserControl>
    public partial class UserControl1 : UserControl
    {
        #region Items
        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(
            "Items",
            typeof(IEnumerable<object>),
            typeof(UserControl1),
            new UIPropertyMetadata(null));
        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        #endregion
        #region Selected
        public static readonly DependencyProperty SelectedProperty =
        DependencyProperty.Register(
            "Selected",
            typeof(object),
            typeof(UserControl1),
            new UIPropertyMetadata(null));
        public object Selected
        {
            get { return (object)GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        #endregion
        public UserControl1()
        {
            InitializeComponent();
        }
    }
