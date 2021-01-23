    private object _callbackContext;
    private async void tbInput_TextChanged(object sender, TextChangedEventArgs e)
    {
      _callbackContext = new object();
      resultStackPanel.Children.Clear();
      if (tbInput.Text == "")
        return;
      Modules.Where(mod => mod.IsApplicable(tbInput.Text))
          .Select(mod => ApplyModuleAsync(mod));
    }
    private async Task ApplyModuleAsync(IModule module)
    {
      var myContext = _callbackContext;
      var element = await module.CalculateOutcome(tbInput.Text);
      if (myContext != _callbackContext || element == null)
        return;
      resultStackPanel.Children.Add(element);
    }
