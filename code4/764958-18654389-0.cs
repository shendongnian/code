    private void AddSaveButton()
    {
        ActionButton b = new ActionButton(GetString(6025));
        b.ID = "ButtonSave";
        b.ClientInstanceName = "ButtonSave";
        b.UseSubmitBehavior = true;
        b.Click += new EventHandler(save_event);
        DivButton.Controls.Add(b);
    }
