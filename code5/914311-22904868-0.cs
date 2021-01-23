        // Initialization
        foreach(XtraTabPage page in xtraTabControl.TabPages) {
            if(page == addNewTabPage) continue;
            page.TabPageWidth = 100; // turn off headers auto-size
        }
    }
    void xtraTabControl_CloseButtonClick(object sender, EventArgs e) {
        ClosePageButtonEventArgs ea = e as ClosePageButtonEventArgs;
        if(ea.Page != addNewTabPage) {
            xtraTabControl.BeginUpdate();
            ((XtraTabPage)ea.Page).Dispose();
    
            int totalWidth = 0;
            var visiblePages =((IXtraTab)xtraTabControl).ViewInfo.HeaderInfo.VisiblePages;
            int totalHeadersGrow = 0;
            for(int i = 0; i < visiblePages.Count; i++) {
                var pageInfo = visiblePages[i];
                if(pageInfo.Page == addNewTabPage) continue;
                totalWidth += pageInfo.Bounds.Width;
                totalHeadersGrow += (pageInfo.Bounds.Width - pageInfo.Page.TabPageWidth);
            }
            int count = xtraTabControl.TabPages.Count - 1;
            int width = totalWidth / count - totalHeadersGrow / (count + 1);
            foreach(XtraTabPage page in xtraTabControl.TabPages) {
                if(page == addNewTabPage) continue;
                page.TabPageWidth = width;
            }
            xtraTabControl.EndUpdate();
        }
    }
