    public UserControl CreateUserControl(string text) {
      Binding binding = new Binding {
        Path = new PropertyPath(BackgroundProperty),
        RelativeSource = new RelativeSource() {
          Mode = RelativeSourceMode.FindAncestor,
          AncestorType = typeof(ListBoxItem)
        }
      };
      var uc = new UserControl {
        Content = new TextBlock {
          Text = text,
          FontSize = 24,
          FontWeight = FontWeights.Bold,
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center
        }
      };
    
      BindingOperations.SetBinding(uc, BackgroundProperty, binding);
      return uc;
    }
