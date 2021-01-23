    var fd = new FixedDocument(); 
    fd.DocumentPaginator.PageSize = new Size(pd.PrintableAreaWidth,fd.PrintableAreaHeight);
    FixedPage page1 = new FixedPage();
    page1.Width = fd.DocumentPaginator.PageSize.Width;
    page1.Height = fd.DocumentPaginator.PageSize.Height;
    UIElement page1Text = pages();
    page1.Children.Add(page1Text);
    PageContent page1Content = new PageContent();
    ((IAddChild)page1Content).AddChild(page1);
    fd.Pages.Add(page1Content);
    
    private UIElement pages()
        {
            Canvas pcan = new Canvas();
    
            TextBlock page1Text = new TextBlock();
            page1Text.Text = "This is a test";
            page1Text.FontSize = 40;
            page1Text.Margin = new Thickness(96);
    
            pcan.Children.Add(page1Text);
    
    
            return pcan;
        }
