    // You need to change List<T> to List<Type>, and you need to only pass types here
    public void subscribe(List<Type> listMessagesTypes)
    {
        foreach(Type messageType in listMessagesTypes)
        {
            // find method "subscribe" on Messenger type
            MethodInfo method = typeof(Messenger).GetMethod("subscribe");
            // create a generic definition of method with specified type
            MethodInfo genericMethod = method.MakeGenericMethod(messageType);
            // invoke this generic method
            // the assumption is that your method signature is like this: doAction(IMessage message)
            genericMethod.Invoke(_messenger, new object[] { new Action<IMessage>(doAction)});
		}
	}
