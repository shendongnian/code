    public static void OpenNewForm(string formName)
    {
        string myNamespace = App.Current.GetType().ToString().Split('.')[0]; // TODO: Improve this method of get the namespace.
    
        var w = (Window)Activator.CreateInstance(null, myNamespace + "." + formName).Unwrap();
        w.Show();
    }
