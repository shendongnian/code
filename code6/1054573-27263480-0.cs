       public class ViewModel
        {
            public ObservableCollection<TabItem> Tabs { get; set; }
            public ViewModel()
            {
                Tabs = new ObservableCollection<TabItem>();
                Tabs.Add(new TabItem { Header = "One", Content = "One's content" });
                Tabs.Add(new TabItem { Header = "Two", Content = "Two's content" });
            }
        }
        public class TabItem
        {
            public string Header { get; set; }
            public string Content { get; set; }
        }
    Here`s the View and VM binding
    
    <Window x:Class="WpfApplication12.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Window.DataContext>
        <ViewModel
            xmlns="clr-namespace:WpfApplication12" />
    </Window.DataContext>
    <TabControl
    ItemsSource="{Binding Tabs}">
    <TabControl.ItemTemplate>
        <!-- this is the header template-->
        <DataTemplate>
            <TextBlock
                Text="{Binding Header}" />
        </DataTemplate>
    </TabControl.ItemTemplate>
    <TabControl.ContentTemplate>
        <!-- this is the body of the TabItem template-->
        <DataTemplate>
            <----- usercontrol namespace goes here--->
        </DataTemplate>
    </TabControl.ContentTemplate>
