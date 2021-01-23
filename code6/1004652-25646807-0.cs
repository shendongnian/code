    private void OnButtonClick(object sender, EventArgs e)
    {
       var vm = this.DataContext as uiElementRendererViewModel; // Get the current view model and cast it to correct type
       vm.ViewModelText = "Enter new text here"; // Update the text
    }
