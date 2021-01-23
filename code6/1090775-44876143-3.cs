    private DebounceDispatcher debounceTimer = new DebounceDispatcher();
    private void TextSearchText_KeyUp(object sender, KeyEventArgs e)
    {
        debounceTimer.Debounce(500, parm =>
        {
            Model.AppModel.Window.ShowStatus("Searching topics...");
            Model.TopicsFilter = TextSearchText.Text;
            Model.AppModel.Window.ShowStatus();
        });
    }
