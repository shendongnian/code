    private bool _retrievedData = false;
    public void RefreshData() {
        // do everything you were doing inside the `txtClientID_OnLeave` handler
        // make sure to set this flag only if the data was successfully retrieved
        // the bottom of the `try` should be good
        _retrievedData = true;
    }
    public void txtClientID_OnLeave(object sender, EventArgs e) {
        RefreshData();
    }
    public void yourButton_Click(object sender, EventArgs e) {
        if (_retrievedData == false)
            RefreshData();
        // do whatever you were doing in this handler because now your textboxes have the
        // data it would have if you had left the textbox without going straight to submit
    }
