    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    public class BoxPanel : StackPanel
    {
      public int Id { get; private set; }
    
      private readonly Border topPanel;
      private readonly StackPanel bottomPanel;
    
      public BoxPanel()
      {
        topPanel = new Border();
        bottomPanel = new StackPanel { Orientation = Orientation.Horizontal };
    
        this.Children.Add(topPanel);
        this.Children.Add(bottomPanel);
      }
    
      public BoxPanel(Box box)
        : this()
      {
        Id = box.Id;
    
        topPanel.Child = new TextBlock
        {
          Text = box.Content,
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center,
          Padding = new Thickness(14),
          Foreground = Brushes.White,
        };
        topPanel.Background = (Id % 2 == 0) ? Brushes.Gray : Brushes.DarkGray;
        topPanel.BorderBrush = Brushes.Black;
        topPanel.BorderThickness = new Thickness(1);
      }
    
      protected override void OnInitialized(EventArgs e)
      {
        base.OnInitialized(e);
    
        this.Loaded += (_, __) => AdjustBottomPanel();
        this.LayoutUpdated += (_, __) => AdjustBottomPanel();
      }
    
      public IReadOnlyCollection<BoxPanel> ChildrenPanel
      {
        get { return bottomPanel.Children.Cast<BoxPanel>().ToArray(); }
      }
    
      public void AddChildPanel(BoxPanel child)
      {
        bottomPanel.Children.Add(child);
        AdjustBottomPanel();
      }
    
      private void AdjustBottomPanel()
      {
        if (!ChildrenPanel.Any())
          return;
    
        var childWidth = Math.Max((Double.IsNaN(this.Width) ? 0 : this.Width), this.ActualWidth)
          / ChildrenPanel.Count;
    
        foreach (var child in ChildrenPanel)
          child.Width = childWidth;
      }
    }
