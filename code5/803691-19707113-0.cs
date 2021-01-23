    testLisBox.ItemTemplate = CreateTemplate();
    testLisBox.ItemsSource = new[] { "Item1", "Item2" };    
    testLisBox.AddHandler(Button.ClickEvent, new RoutedEventHandler(buttonClick));
    private DataTemplate CreateTemplate()
            {          
                string xaml =
    @"<DataTemplate
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
    <Button Name=""testbutton"">123123</Button>
    </DataTemplate>";
                return (DataTemplate)System.Windows.Markup.XamlReader.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)));            
            }
    private void buttonClick(object sender, RoutedEventArgs e)
            {
                if (e.OriginalSource is Button && ((Button)e.OriginalSource).Name == "testbutton")
                {
                    MessageBox.Show("123");    
                }            
            }
