    public int num = 60;    
    public int SelectCountMethod()
        {                  
            num = SomeMethod(); //Returns int
            ScriptManager.RegisterStartupScript(this,
                                                            this.GetType(),
                                                            "Funct",
                                                            "myMsg = " + num + ";",
                                                            true);
            return num;
        }
