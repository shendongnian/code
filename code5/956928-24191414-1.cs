    var test = dtActions.AsEnumerable().Where(z =>
        (string.IsNullOrEmpty(txtFirstName.Text) ? true : z.Field<string>("FirstName").ToUpper().StartsWith(txtFirstName.Text.ToUpper())) &&
        (string.IsNullOrEmpty(txtDisplayName.Text) ? true : z.Field<string>("DisplayName").ToUpper().StartsWith(txtDisplayName.Text.ToUpper())) &&
        (string.IsNullOrEmpty(txtCreatedBy.Text) ? true : z.Field<string>("CreatedBy").ToUpper().StartsWith(txtCreatedBy.Text.ToUpper()))
    );
