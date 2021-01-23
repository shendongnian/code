    private void SelectionSVC_SelectionChanged(object sender, EventArgs e)
    {
        var selectionSVC = sender as ISelectionService;
        if (selectionSVC == null) return;
        try
        {
            selectionSVC.SelectionChanged -= SelectionSVC_SelectionChanged;
            if ((Control.ModifierKeys & (Keys.Shift | Keys.Control)) > Keys.None)
            {
                var selection = selectionSVC.GetSelectedComponents()
                    .Cast<object>().LastOrDefault();
                if (selection != null)
                    selectionSVC.SetSelectedComponents(new[] { selection },
                        SelectionTypes.Primary | SelectionTypes.Add);
            }
        }
        finally
        {
            selectionSVC.SelectionChanged += SelectionSVC_SelectionChanged;
        }
    }
