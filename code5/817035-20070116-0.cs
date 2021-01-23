    <DataGridHyperlinkColumn Binding="{Binding Link}">
        <DataGridHyperlinkColumn.ElementStyle>
            <Style>
                <EventSetter Event="Hyperlink.Click" Handler="DG_Hyperlink_Click"/>
            </Style>
        </DataGridHyperlinkColumn.ElementStyle>
    </DataGridHyperlinkColumn>
    
    private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
    {
        Hyperlink link = (Hyperlink)e.OriginalSource;
        Process.Start(link.NavigateUri.AbsoluteUri);
    }
