    public static void Search(string name, string city)
    {
        Search(name, 21, city);
    }
    public static void Search(string name, int age = 21, string city = "Tehran")
    {
        MessageBox.Show(String.Format("Name = {0} - Age = {1} - City = {2}", 
            name, age, city));
    }
