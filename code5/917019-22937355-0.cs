    public static void Main()
    {
          const string jsonString = "{ \"id\":15, \"username\":\"patrick\" }";
          User u = JsonConvert.DeserializeObject<User>(jsonString);
    } 
