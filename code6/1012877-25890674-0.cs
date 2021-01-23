    foreach (var data in DonneesBrutes.SelectedItems)
    {
        foreach (var item in viewModel.ActiviteCollection.Where(c => c.PMRQTOTMActivite == DonneesBrutes.CurrentItem.ToString()))
        {
            item.MyBoolean = !item.MyBoolean;
        }
    }
