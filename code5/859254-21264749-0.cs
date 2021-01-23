App.xaml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="Dictionary/StyleDictionary.xaml"/>
                <ResourceDictionary Source="Dictionary/ColorDictionary.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>        
Code-behind
    private void Window_ContentRendered(object sender, EventArgs e)
    {
        SolidColorBrush MyBrush = Brushes.Black;
        Application.Current.Resources["themeColour"] = MyBrush;
    }
