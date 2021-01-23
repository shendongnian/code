    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace App4
    {
        public class CyclingFlipView : FlipView
        {
            public async Task Cycle()
            {
                if (this.ItemsSource != null)
                {
                    var list = (IList)this.ItemsSource;
    
                    if (list.Count == 0)
                    {
                        return;
                    }
    
                    SelectionChangedEventHandler handler = null;
                    var tcs = new TaskCompletionSource<bool>();
                    handler = (s, e) =>
                    {
                        tcs.SetResult(true);
                        this.SelectionChanged -= handler;
                    };
                    this.SelectionChanged += handler;
                    this.SelectedIndex = (this.SelectedIndex + 1) % list.Count;
                    await tcs.Task;
                    await Task.Delay(500);
                    var i = this.SelectedIndex;
                    this.SelectedItem = null;
    
                    var item = list[0];
                    list.RemoveAt(0);
                    list.Add(item);
                    this.SelectedIndex = i - 1;
                }
                else if (this.Items != null)
                {
                    if (this.Items.Count == 0)
                    {
                        return;
                    }
    
                    SelectionChangedEventHandler handler = null;
                    var tcs = new TaskCompletionSource<bool>();
                    handler = (s, e) =>
                    {
                        tcs.SetResult(true);
                        this.SelectionChanged -= handler;
                    };
                    this.SelectionChanged += handler;
                    this.SelectedIndex = (this.SelectedIndex + 1) % this.Items.Count;
                    await tcs.Task;
                    await Task.Delay(500);
                    var i = this.SelectedIndex;
                    this.SelectedItem = null;
    
                    var item = this.Items[0];
                    this.Items.RemoveAt(0);
                    this.Items.Add(item);
                    this.SelectedIndex = i - 1;
                }
            }
    
            public async Task AutoCycle()
            {
                while (true)
                {
                    this.Cycle();
                    await Task.Delay(1000);
                }
            }
        }
    
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                var fv = new CyclingFlipView();
                fv.ItemsSource = new ObservableCollection<int>(Enumerable.Range(0, 4));
                fv.ItemTemplate = (DataTemplate)this.Resources["ItemTemplate"];
                this.Content = fv;
                fv.AutoCycle();
            }
        }
    }
