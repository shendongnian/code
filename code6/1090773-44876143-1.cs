    // declare the debounceTimer that will be reused
    private DebounceDispatcher debounceTimer = new DebounceDispatcher();
           
    // event handler
    private void TextSearchText_KeyUp(object sender, KeyEventArgs e)
    {
        debounceTimer.Debounce(200, (p) =>
        {                
            Model.AppModel.Window.ShowStatus("Searching topics...");
            Model.TopicsFilter = TextSearchText.Text;
            Model.AppModel.Window.ShowStatus();
        });        
    }
