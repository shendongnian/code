    public static void Enterusername(string testusername)
    {
        Driver.Instance.FindElement(By.Id("MainContent_RegisterUser_CreateUserStepContainer_UserName")).SendKeys(testusername);
    }
    
    public static void EnterEmail(string testemail)
    {
        Driver.Instance.FindElement(By.Id("MainContent_RegisterUser_CreateUserStepContainer_Email")).SendKeys(testemail);
    }
