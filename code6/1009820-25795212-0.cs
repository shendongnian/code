	class BaseObject
	{
		//This class contains no members
	}
	class ExtendedObject : BaseObject
	{
		public string Name;
	}
    void Example()
    {
        ExtendedObject extended = new ExtendedObject {Name = "Default"};
        BaseObject downcast = (BaseObject)extended;
        //This won't compile - Name is undefined because it's not defined in your base
        downcast.Name;
    }
