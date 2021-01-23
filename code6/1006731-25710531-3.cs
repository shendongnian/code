    public void Test()
    {
      ArrayList a = new ArrayList();
      a.Add(new User() {id = "001", pwd = "pass1"});
      a.Add(new User() {id = "002", pwd = "pass2"});
      Writefile(a, "testusers.bin");
      a = ReadFile("testusers.bin");
      User user = (User) a[0];
      Console.WriteLine(user.id + " " + (user.pwd);
    }
