    var tbNameX = (TextBox)this.GetType().GetProperty(tbName + variable).GetValue(this, null);
    var tbLastnameX = (TextBox)this.GetType().GetProperty(tbLastname + variable).GetValue(this, null);
    var tbEmailX = (TextBox)this.GetType().GetProperty(tbEmail + variable).GetValue(this, null);
    newUsers.Add(new ClassLibrary.UserClass
    (
        "AAAAAAAA",
        tbNameX.Text,    //Is it possible to do something like this?
        " ",
        tbNameX.Text,
        tbEmailX.Text,
        " ",
        "0497111111",
        "0611111111",
        "USER"
    ));
