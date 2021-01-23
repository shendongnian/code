    settings.Columns.Add(c =>
    {
        c.Caption = "Nurse Name";
        c.SetDataItemTemplateContent(t =>
        {
            Html.DevExpress().Label(
                l => {
                    l.Text = String.Format("{0} {1}", DataBinder.Eval(t.DataItem, "NurseFirstName"), DataBinder.Eval(t.DataItem, "NurseLastName"));
                }).Render();
        });
    });
