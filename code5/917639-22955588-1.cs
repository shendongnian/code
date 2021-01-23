    private static void Test()
    {
    	Type myType = typeof(SomeClass);
    	object myInstance = Activator.CreateInstance(myType);
    	if (Program.<Test>o__SiteContainer0.<>p__Site1 == null)
    	{
    		Program.<Test>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(int), typeof(Program)));
    	}
    	Func<CallSite, object, int> arg_AA_0 = Program.<Test>o__SiteContainer0.<>p__Site1.Target;
    	CallSite arg_AA_1 = Program.<Test>o__SiteContainer0.<>p__Site1;
    	if (Program.<Test>o__SiteContainer0.<>p__Site2 == null)
    	{
    		Program.<Test>o__SiteContainer0.<>p__Site2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "SomeMethod", null, typeof(Program), new CSharpArgumentInfo[]
    		{
    			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
    		}));
    	}
    	int result = arg_AA_0(arg_AA_1, Program.<Test>o__SiteContainer0.<>p__Site2.Target(Program.<Test>o__SiteContainer0.<>p__Site2, myInstance));
    }
