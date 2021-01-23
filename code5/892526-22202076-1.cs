    public MyClass GetValues()
    {
        var myClass = new MyClass
        {
            ProjectNumber = ddlProjectnumber.Text.Split('-').First().Trim(),
            Task = tbTask.Text,
            Substitute = ddlSubstitute.Text,
            Category = ddlCategory.Text,
            Subcategory = ddlSubcategory.Text,
            Finished = cbFinished.Checked,
            Journey = cbJourney.Checked
        };
        if (propertychanged)
            myClass.PropChangedDate = DateTime.Now;
        return myClass;
    }
