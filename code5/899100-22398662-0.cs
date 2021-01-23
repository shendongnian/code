    public static void Search(string name, int? age = null, string city = null)
    {
        MessageBox.Show(String.Format("Name = {0} - Age = {1} - City = {2}", 
            name, age ?? 21, city ?? "Tehran"));
    }
