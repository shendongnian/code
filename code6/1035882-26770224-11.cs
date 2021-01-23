    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
        }
    
        public class MainViewModel
        {
            public List<AttributeUpdateViewModel> AttributeUpdateViewModels { get; set; }
    
            public MainViewModel()
            {
                var rawAttributeUpdates = new[]
                {
                    new AttributeUpdate { Number = 1, Attribute = "Height", Old = "1.1", New = "0.9" },
                    new AttributeUpdate { Number = 1, Attribute = "Material", Old = "Steel1", New = "Steel2" },
                    new AttributeUpdate { Number = 2, Attribute = "Color", Old = "Green", New = "Light-Green" },
                    new AttributeUpdate { Number = 3, Attribute = "Attribute4", Old = "Old4", New = "New4" },
                    new AttributeUpdate { Number = 3, Attribute = "Attribute5", Old = "Old5", New = "New5" },
                    new AttributeUpdate { Number = 3, Attribute = "Attribute6", Old = "Old6", New = "New6" },
                    new AttributeUpdate { Number = 4, Attribute = "Attribute7", Old = "Old7", New = "New7" },
                    new AttributeUpdate { Number = 5, Attribute = "Attribute8", Old = "Old8", New = "New8" },
                    new AttributeUpdate { Number = 5, Attribute = "Attribute9", Old = "Old9", New = "New9" },
                };
                var groupedAttributeUpdates = rawAttributeUpdates
                    .OrderBy(x => x.Number)
                    .GroupBy(x => x.Number);
                AttributeUpdateViewModels = rawAttributeUpdates
                    .Select(x => GetAttributeUpdateRow(x, groupedAttributeUpdates))
                    .ToList();
            }
    
            private AttributeUpdateViewModel GetAttributeUpdateRow(
                AttributeUpdate attributeUpdate,
                IEnumerable<IGrouping<int, AttributeUpdate>> groupedAttributeUpdates)
            {
                var lastInGroup = groupedAttributeUpdates.Single(x => x.Key == attributeUpdate.Number).Last();
                return new AttributeUpdateViewModel
                {
                    Number = attributeUpdate.Number,
                    Attribute = attributeUpdate.Attribute,
                    New = attributeUpdate.New,
                    Old = attributeUpdate.Old,
                    IsLastInGroup = attributeUpdate == lastInGroup
                };
            }
        }
    
        public class AttributeUpdate
        {
            public int Number { get; set; }
            public string Attribute { get; set; }
            public string Old { get; set; }
            public string New { get; set; }
        }
    
        public class AttributeUpdateViewModel
        {
            public int Number { get; set; }
            public string Attribute { get; set; }
            public string Old { get; set; }
            public string New { get; set; }
    
            public bool IsLastInGroup { get; set; }
    
            public Thickness BorderThickness
            {
                get { return IsLastInGroup ? new Thickness(0, 0, 0, 1) : new Thickness(); }
            }
        }
    }
