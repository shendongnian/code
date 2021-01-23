    protected override void OnMove(EventArgs e)
    {
        //
        // Get the MDI Client window reference
        //
        MdiClient mdiClient = null;
        foreach(Control ctl in MdiParent.Controls)
        {
            mdiClient = ctl as MdiClient;
            if(mdiClient != null)
                break;
        }
        //
        // Don't allow moving form outside of MDI client bounds
        //
        if(Left < mdiClient.ClientRectangle.Left)
            Left = mdiClient.ClientRectangle.Left;
        if(Top < mdiClient.ClientRectangle.Top)
            Top = mdiClient.ClientRectangle.Top;
        if(Top + Height > mdiClient.ClientRectangle.Height)
            Top = mdiClient.ClientRectangle.Height - Height;
        if(Left + Width > mdiClient.ClientRectangle.Width)
            Left = mdiClient.ClientRectangle.Width - Width;
        base.OnMove(e);
    }
