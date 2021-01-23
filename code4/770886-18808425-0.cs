    using FastMember;
	class RequiredAttribute : Attribute
	{
	}
	abstract class Parent
	{
		abstract protected void _run();
		private List<string> required_prop_names = new List<string>();
		private ObjectAccessor accessor;
		public Parent()
		{
			// create list of properties that are 'required'
			required_prop_names = this.GetType().GetFields()
				.Where(prop => Attribute.IsDefined(prop, typeof(RequiredAttribute)))
				.Select(prop => prop.Name)
				.ToList<string>();
			// create FastMember accessor
			accessor = ObjectAccessor.Create(this);
		}
		public void run()
		{
			// set all to null
			required_prop_names.ForEach(x => accessor[x] = null);
			// call child
			_run();
			// validate
			foreach (string prop_name in required_prop_names){
				Console.WriteLine("Value of {0} is {1}", prop_name, accessor[prop_name]);
				if (accessor[prop_name] == null){
					Console.WriteLine("Null value found on {}!", prop_name);
				}
			}
		}
	}
	class Child : Parent
	{
		[Required]
		public object value1 = "something";
		[Required]
		public object value2 = "something";
		// not required..
		public object value3;
		override protected void _run()
		{
			// This must set all 'required' properties' values, otherwise the Parent should throw.
			value1 = "something else";
			//value2 = "something else";
		}
	}
