    private bool _programmaticChange;
    private void SomeMethod()
    {
        _programmaticChange = true;
        dataGridView.ClearSelection();
        _programmaticChange = false;
    }
    private void dataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_programmaticChange) return;
        // some code
    }
