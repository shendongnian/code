	class Example2
	{
		public string UserName {private get;set;}
		public string Password{private get;set;}
		public List<ObjectDefinition> function1(string option) 
		{
			var example1 = CreateExample1(option);
			//Other codes
		}
		public List<ObjectDefinition> function2(string option,string other,string other_more_params) 
		{
			var example1 = CreateExample1(option);
			//Other codes
		}
		public List<ObjectDefinition> function3(string option) 
		{
			var example1 = CreateExample1(option);
			//Other codes
		}
		//so on
		public Example1 CreateExample1(string option)
		{
			Example1 obj=new Example1();
			obj.username =this.UserName ;
			obj.password=this.Password;
			obj.callfunction(option); 
			return obj;		
		}
	}
	
