    foreach (IModule mod in Modules)
    {
        if (mod.IsApplicable(tbInput.Text))
        {
            tasks.Add(mod.CalculateOutcome(tbInput.Text).ContinueWith(resultTask =>
            {
                 if (resultTask.Result != null)
                 {
                     resultStackPanel.Children.Add(resultTask.Result);
                 }
            }, TaskContinuationOptions.OnlyOnRanToCompletion));            
        }
    }
    await Task.WhenAll(tasks.ToArray());
