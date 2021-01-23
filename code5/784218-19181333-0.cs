    class Example1
    {
       public string username {private get;set;}
       public string password{private get;set;}
       public  obj[] callfunction(string value){//code}
    }
    class Example2
    {
       public string UserName {private get;set;}
       public string Password{private get;set;}
       public List<ObjectDefinition> function1(string option) 
       {
        Example1 obj=GetExample1Instance();
        obj.callfunction(option)
        //Other codes
       }
       public List<ObjectDefinition> function2(string option,string other,string other_more_params) 
       {
        Example1 obj=GetExample1Instance();
        obj.callfunction(other)
        //Other codes
       }
       public List<ObjectDefinition> function3(string option) 
       {
        Example1 obj=GetExample1Instance();
        obj.callfunction(option)
        //Other codes
       }
       
       private Example1 GetExample1Instance()
       {
    	return new Example1 { username = this.UserName, password = this.Password }
       }
       //so on
    }
