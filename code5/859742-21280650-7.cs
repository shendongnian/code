    public static void MakeQuack(object duck)
    {
		MethodInfo quackMethod = duck.GetType().GetMethod("Quack", Type.EmptyTypes, null);
		if (quackMethod!=null)
		{
			quackMethod.Invoke(duck, new object[] { });
		}
		else
		{
			throw new ArgumentException("No Quack() method found on target");
		}
    }
