	class Example2
	{
		public string UserName {private get;set;}
		public string Password{private get;set;}
		public List<ObjectDefinition> function1(string option) 
		{
			SetExample1Data(obj, option);
			//Other codes
		}
		public List<ObjectDefinition> function2(string option,string other,string other_more_params) 
		{
			SetExample1Data(obj, option);
			//Other codes
		}
		public List<ObjectDefinition> function3(string option) 
		{
			SetExample1Data(obj, option);
			//Other codes
		}
		//so on
		public void SetExample1Data(Example1 obj, string option)
		{
			obj.username =this.UserName ;
			obj.password=this.Password;
			obj.callfunction(option);   
		}
	}
