    private const int SB_VERT = 1;
    public void ScrollList() {
        int items_on_page = (listView1.Height-26)/17;
        ScrollEventArgs sarg = new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_VERT));
        items_count = listView1.Items.Count;
        int scroll_pos = listView1.ScrollPosition;
        int left_pos = items_count-scroll_pos;
           
        if(left_pos<=items_on_page+2) {
            // load more data into the listview
        }
    }
    protected override void WndProc(ref Message m)   {
        base.WndProc(ref m);
        switch(m.Msg)
        {
            case WM_VSCROLL:
                ScrollList();
            break;
            case WM_MOUSEWHEEL:
                ScrollList();
            break;
         }
    }
