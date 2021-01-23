    bool _suppressEvent = false;
    public void fillListBoxData() 
    {
        try
        {
             _suppressEvent = true;
             ...Do whatever you want here
        }
        finally
        {
            _suppressEvent = false;
        }
    }
    void volList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if( _suppressEvent ) return;
        ...
    }
