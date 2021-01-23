    private void button_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            OpenWin("window2", new Uri(@"window2.xaml", UriKind.Relative), "Window2Label");
        }
        catch (Exception ex)
        {
            Message.Show(ex);
        }
    }
    
    public static DocumentPanel OpenWin(string namePainelItem, Uri xamlPath, string caption = "", RoutedEventHandler unloadEvent = null, bool closeOpenWin = false)
    {
        try
        {        
            if (closeOpenWin)
            {
                CloseWin(namePainelItem, false);
            }
    
            DocumentPanel panel1 = GetWin(namePainelItem);
            if (panel1 == null)
            {
                panel1 = new DocumentPanel();
                panel1.Caption = caption;
                panel1.Name = namePainelItem;
                panel1.Content = xamlPath;
    
                if (unloadEvent != null)
                {
                    panel1.Unloaded += unloadEvent;                        
                }            
    
                hdl.dockLayoutManager.DockController.Insert(hdl.documentGroup1, panel1, 1);
                hdl.dockLayoutManager.DockController.ActiveItem = panel1;
            }
            else
            {
                if (panel1.Visibility != Visibility.Visible)
                    panel1.Visibility = Visibility.Visible;
    
                if(panel1.IsClosed)
                    panel1.Closed = false;                    
    
                hdl.dockLayoutManager.DockController.ActiveItem = panel1;
            }
            return panel1;
        }
        catch (Exception ex)
        {
            Message.Show(ex);                
        }
        return new DocumentPanel();
    }
    
    
    public static void CloseWin(string namePainelItem)
    {
        try
        {
            BaseLayoutItem item = hdl.dockLayoutManager.GetItem(namePainelItem);
    
            if (item != null)
            {
                hdl.documentGroup1.Items.Remove(item);
                hdl.dockLayoutManager.DockController.RemovePanel((DocumentPanel)item);
                item = null;
            }
        }
        catch (Exception ex)
        {
            Message.Show(ex);
        }
    }
