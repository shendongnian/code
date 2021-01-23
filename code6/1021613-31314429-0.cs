    <Frame Name="fr_View" ContentRendered="fr_View_ContentRendered"/>
    
    
    private void fr_View_ContentRendered(object sender, System.EventArgs e)
    {
         ResourceDictionary myResourceDictionary = new ResourceDictionary();
         myResourceDictionary.Source = new Uri("Dictionary1.xaml", UriKind.Relative);
         (fr_View.Content as System.Windows.Controls.Page).Resources.MergedDictionaries.Add(myResourceDictionary);
    }
