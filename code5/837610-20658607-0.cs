    namespace App01.Win8.Controls
    {
        public sealed partial class VoidPanel : UserControl
        {
            private ObservableCollection<VoidListElement> names;
        **public ObservableCollection<VoidListElement> names
        { set; get; }**
            public VoidPanel()
            {
                **names = new ObservableCollection<VoidListElement>();**
                names.Add(new VoidListElement("ITEM-A", "27017"));
                names.Add(new VoidListElement("ITEM-B", "27018"));
    
                this.DataContext = this;
                **this.InitializeComponent();**
            }
        }
    }
