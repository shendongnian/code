    using (var dbContext = new DataClasses1DataContext()) {
        var record = new AutorizedActivity();
        record.MbrId = (int) ddlMember.SelectedValue;
        record.ActId = (int) ddlActivity.SelectedValue;
        dbContext.AutorizedActivities.InsertOnSubmit(record);
        dbContext.SubmitChanges();
    }
