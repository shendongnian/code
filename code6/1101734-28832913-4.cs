    void HideImage(int elementIndex)
    {
        var container = lst1.ContainerFromIndex(elementIndex) as ListViewItem;
    
       var imageSender = (container.Content as Grid).Children[0] as Image;
       imageSender.Visibility = Visibility.Collapsed;
    }
