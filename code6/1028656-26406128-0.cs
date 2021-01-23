    using (new LanguageSwitcher("en-gb"))
    {
        var rootItem = currentDatabase.GetItem(RootItemPath);
        var item = rootItem.Add(selectedItem.Name, CommunityProjectTemplateId);
    
        // Do your editing on item here...
    }
