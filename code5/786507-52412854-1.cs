    // Create a "Parent" class that has some attributes.
	public class Parent
	{
		public string attribute_one { get; set; }
		public string attribute_two { get; set; }
		public string attribute_three { get; set; }
	}
    // Define a class called "Child" that inherits the
    // attributes of the "Parent" class.
	public class Child : Parent
	{
		public string attribute_four { get; set; }
		public string attribute_five { get; set; }
		public string attribute_six { get; set; }
	}
    // Create a new instance of the "Child" class with
    // all attributes of the base and derived classes.
	Child child = new Child {
		attribute_one = "interesting";
		attribute_two = "strings";
		attribute_three = "to";
		attribute_four = "put";
		attribute_five = "all";
		attribute_six = "together";
	};
    // Create an instance of the base class that we will
    // populate with the derived class attributes.
	Parent parent = new Parent();
    // Using reflection we are able to get the attributes
    // of the base class from the existing derived class.
	foreach(PropertyInfo property in child.GetType().BaseType.GetProperties())
	{
        // Set the values in the base class using the ones
        // that were set in the derived class above.
		property.SetValue(parent, property.GetValue(child));
	}
