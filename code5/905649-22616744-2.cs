    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WinRTXamlToolkit.Controls.Extensions;
    
    namespace ListViewItemCentering
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private Random random = new Random();
            public MainPage()
            {
                this.InitializeComponent();
                this.listView.ItemsSource = Enumerable.Range(1, 1000);
                this.listView.SelectionChanged += OnListViewSelectionChanged;
            }
    
            private async void OnListViewSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
            {
                if (listView.SelectedItem == null)
                {
                    return;
                }
    
                var item = listView.SelectedItem;
    
                // Calculations relative to screen or ListView
                var listViewItem = (FrameworkElement)listView.ContainerFromItem(item);
    
                if (listViewItem == null)
                {
                    listView.ScrollIntoView(item);
                }
    
                while (listViewItem == null)
                {
                    await Task.Delay(1); // wait for scrolling to complete - it takes a moment
                    listViewItem = (FrameworkElement)listView.ContainerFromItem(item);
                }
    
                var topLeft =
                    listViewItem
                        .TransformToVisual(listView)
                        .TransformPoint(new Point()).Y;
                var lvih = listViewItem.ActualHeight;
                var lvh = listView.ActualHeight;
                var desiredTopLeft = (lvh - lvih) / 2.0;
                var desiredDelta = topLeft - desiredTopLeft;
    
                // Calculations relative to the ScrollViewer within the ListView
                var scrollViewer = listView.GetFirstDescendantOfType<ScrollViewer>();
                var currentOffset = scrollViewer.VerticalOffset;
                var desiredOffset = currentOffset + desiredDelta;
                scrollViewer.ScrollToVerticalOffset(desiredOffset);
                
                // better yet if building for Windows 8.1 to make the scrolling smoother use:
                // scrollViewer.ChangeView(null, desiredOffset, null);
            }
    
            private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                this.listView.SelectedIndex = random.Next(0, ((IEnumerable<int>)this.listView.ItemsSource).Count());
            }
        }
    }
