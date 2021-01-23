    //Text
            MenuItem menuText = new MenuItem();
            menuText.IsEnabled = false;
            var textBinding = new Binding();
            textBinding.Source = sender;
            textBinding.Path = new PropertyPath("Text");
            BindingOperations.SetBinding(menuText, MenuItem.HeaderProperty, textBinding);
            contxt.Items.Add(menuText);
            //Font Size Menu Header
            MenuItem menuSizeLabel = new MenuItem();
            menuSizeLabel.Header = "Font Size";
            menuSizeLabel.IsEnabled = false;
            contxt.Items.Add(menuSizeLabel);
            //Font Size Menu Item
            TextBox tbxSize = new TextBox();
            Binding FontSizeBinding = new Binding();
            FontSizeBinding.Source = sender;
            FontSizeBinding.Path = new PropertyPath("FontSize");
            FontSizeBinding.Converter = new DoubleStringConverter();
            FontSizeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            FontSizeBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(tbxSize, TextBox.TextProperty, FontSizeBinding);
            contxt.Items.Add(tbxSize);
            //Font Size Menu Header
            MenuItem menuFontLabel = new MenuItem();
            menuFontLabel.Header = "Font Family";
            menuFontLabel.IsEnabled = false;
            contxt.Items.Add(menuFontLabel);
            //Font Menu Item
            ComboBox cbxFont = new ComboBox();
            cbxFont.ItemsSource = new ObservableCollection<FontFamily>(Fonts.SystemFontFamilies.OrderBy(i => i.ToString()));
            Binding FontBinding = new Binding("FontFamily");
            FontBinding.Source = sender;
            FontBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            FontBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(cbxFont, ComboBox.SelectedItemProperty, FontBinding);
            contxt.Items.Add(cbxFont);
