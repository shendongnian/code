	public class Parent
	{
		public string attribute_one { get; set; }
		public string attribute_two { get; set; }
		public string attribute_three { get; set; }
	}
	public class Child : Parent
	{
		public string attribute_four { get; set; }
		public string attribute_five { get; set; }
		public string attribute_six { get; set; }
	}
	Child child = new Child {
		attribute_one = "interesting";
		attribute_two = "strings";
		attribute_three = "to";
		attribute_four = "put";
		attribute_five = "all";
		attribute_six = "together";
	};
	Parent parent = new Parent();
	foreach(PropertyInfo property in child.GetType().BaseType.GetProperties())
	{
		property.SetValue(parent, property.GetValue(child));
	}
