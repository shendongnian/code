    using PhoneApp4.Resources;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using Microsoft.Phone.Controls;
    namespace PhoneApp4
    {
        public partial class MainPage : PhoneApplicationPage
        {
            public MainPage()
            {
                InitializeComponent();
                ObservableCollection<RCLocation> dropOffs = new ObservableCollection<RCLocation>();
                lstDropOff.ItemsSource = dropOffs;
                dropOffs.Add(new RCLocation { Id = "1", Name = "Tester", Checked = true });
                dropOffs.Add(new RCLocation { Id = "1", Name = "Tester", Checked = true });
                dropOffs.Add(new RCLocation { Id = "1", Name = "Tester", Checked = true });
                dropOffs.Add(new RCLocation { Id = "1", Name = "Tester", Checked = true });
            }
        }
        class RCLocation 
        {
            private string _id;
            private string _name;
            private bool _checked;
    
            public string Id { get; set; }
            public string Name { get; set; }
            public bool Checked { get; set; }
        }
    }
