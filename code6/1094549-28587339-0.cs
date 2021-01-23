    private static bool Filter(Menu item, Func<Menu,bool> predicate)
    {
        bool isVisible = predicate(item) ;
        bool isChildrenVisible = (item.Children != null && item.Children.Count(c => Filter(c,predicate))>0);
        item.IsVisible = isVisible || isChildrenVisible;
        return isVisible;
     }
