    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    
    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
    
        boxPanelRoot = new BoxPanel();
        LayoutRoot.Children.Add(boxPanelRoot);
    
        this.Loaded += (_, __) => PopulateBoxPanel();
      }
    
      private readonly IList<Box> Boxes = new List<Box>
      {
        new Box("1st", 1, 0),
        new Box("2nd 1", 2, 1),
        new Box("2nd 2", 3, 1),
        new Box("3rd 1", 4, 2),
        new Box("3rd 2", 5, 2),
        new Box("3rd 3", 6, 3),
        new Box("4th 1", 7, 4),
        new Box("4th 2", 8, 5),
        new Box("4th 3", 9, 5),
        new Box("4th 4", 10, 6),
        new Box("4th 5", 11, 6),
      };
    
      private readonly BoxPanel boxPanelRoot;
    
      private void PopulateBoxPanel()
      {
        foreach (var box in Boxes)
        {
          var existingPanels = boxPanelRoot.GetDescendants() // See VisualTreeHelperExtensions.GetDescendants method of WinRT Xaml Toolkit
            .OfType<BoxPanel>()
            .ToArray();
    
          if (existingPanels.Any(x => x.Id == box.Id))
            continue;
    
          var parent = existingPanels.FirstOrDefault(x => x.Id == box.ParentId);
          if (parent == null)
            parent = boxPanelRoot;
    
          parent.AddChildPanel(new BoxPanel(box));
        }
      }
    }
