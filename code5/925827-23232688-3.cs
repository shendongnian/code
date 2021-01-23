    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.Phone.Controls;
    
    namespace PhoneApp1
    {
        public partial class MainPage : PhoneApplicationPage
        {
            private List<string> populationOfItems = new List<string>
            {
                "one",
                "two",
                "three",
                "four",
                "five"
            };
            private ObservableCollection<string> itemsToView = new ObservableCollection<string>();
    
            public MainPage()
            {
                InitializeComponent();
                this.DataContext = this.itemsToView;
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                this.Button1.IsEnabled = false;
                var items = await PopulateListAsync();
                itemsToView.Clear();
                await Task.Delay(100);
                itemsToView.Add("FIRSTELEMENT");
                foreach (var item in items)
                {
                    await Task.Delay(10);
                    itemsToView.Add(item);
                }
                this.Button1.IsEnabled = true;
            }
            private async Task<IEnumerable<string>> PopulateListAsync()
            {
                await Task.Delay(100)
                    .ConfigureAwait(continueOnCapturedContext: false);
                return populationOfItems;
            }
        }
    }
