    var bindableTemplate = lv.ItemTemplate as IBindableTemplate;
    foreach (ListViewItem item in lv.Items)
    {
        var dic = bindableTemplate.ExtractValues(item).Cast<System.Collections.DictionaryEntry>().ToDictionary(k => (string)k.Key, v => v.Value);
        var provider = new DictionaryValueProvider<object>(dic, System.Globalization.CultureInfo.InvariantCulture);
        
        // Now we can update the item.
        TryUpdateModel<RoleInfo>(model, provider);
    }
