    void DoWork() {
        ... execute your first query
        ... populate your listbox
        var doesExist = myContext.Table2.Any(m => m.UserId == 99);
        yourButton.Visible = !doesExist;
    }
