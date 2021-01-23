    public class ContextMenuExtension
    {
        public static bool GetHideOnEmpty(DependencyObject obj)
        {
            return (bool)obj.GetValue(HideOnEmptyProperty);
        }
        public static void SetHideOnEmpty(DependencyObject obj, bool value)
        {
            obj.SetValue(HideOnEmptyProperty, value);
        }
        public static readonly DependencyProperty HideOnEmptyProperty =
            DependencyProperty.RegisterAttached("HideOnEmpty", typeof(bool), typeof(ContextMenuExtension), new UIPropertyMetadata(false, HideOnEmptyChanged));
        private static void HideOnEmptyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var contextMenu = d as ContextMenu;
            if (contextMenu == null)
                return;
            contextMenu.Loaded += ContextMenu_Loaded;
        }
        private static void ContextMenu_Loaded(object sender, RoutedEventArgs e)
        {
            var contextMenu = sender as ContextMenu;
            var hideOnEmpty = GetHideOnEmpty(contextMenu);
            HideContextMenu(contextMenu, hideOnEmpty);
        }
        //This is where we check if all the items are not visible
        private static void HideContextMenu(ContextMenu contextMenu, bool val)
        {
            //First, we have to know if the HideOnEmpty property is set to true. 
            if (val)
            {
                //Check if the contextMenu is either null or empty
                if (contextMenu.Items == null || contextMenu.Items.Count < 1)
                    contextMenu.Visibility = Visibility.Collapsed; //Hide the contextMenu
                else
                {
                    bool hide = true;
                    //Check if all the items are not visible.  
                    foreach (MenuItem i in contextMenu.Items)
                    {
                        if (i.Visibility == Visibility.Visible)
                        {
                            hide = false;
                            break;
                        }
                    }
                    //If one or more items above is visible we won't hide the contextMenu.
                    if (!hide)
                        contextMenu.Visibility = Visibility.Visible;
                    else
                        contextMenu.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
