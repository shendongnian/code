    private void btnAppBar_ReloadMainPage_Click(object sender, EventArgs e)
    {
        // calling a method of the page:
        ((MainPage)App.RootFrame.Content).MyMethod();
        // accessing a value:
        var mValue = MainPage.myValue.toString();
    }
