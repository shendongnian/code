            ComboBox headerCombo = new ComboBox() { HorizontalAlignment = System.Windows.HorizontalAlignment.Left };
            Binding myBinding = new Binding()
            {
                ElementName = "columnCategory",
                Path = new PropertyPath("ActualWidth"),
                Converter = new RightMarginSetter(),
                ConverterParameter = 20
            };
            headerCombo.SetBinding(ComboBox.WidthProperty, myBinding);
            DataGridTextColumn columnCategory = new DataGridTextColumn() { Header = headerCombo };
