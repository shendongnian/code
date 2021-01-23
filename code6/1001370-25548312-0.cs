    using (new EventDisabler())
    {
        item.Editing.BeginEdit();
        item.Editing.EndEdit();
    }
