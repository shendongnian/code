	private static void Main(string[] args)
	{
		object param = null;
		if (Program.<Main>o__SiteContainer0.<>p__Site1 == null)
		{
			Program.<Main>o__SiteContainer0.<>p__Site1 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Assert", null, typeof(Program), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		Action<CallSite, Type, object> arg_CB_0 = Program.<Main>o__SiteContainer0.<>p__Site1.Target;
		CallSite arg_CB_1 = Program.<Main>o__SiteContainer0.<>p__Site1;
		Type arg_CB_2 = typeof(Debug);
		if (Program.<Main>o__SiteContainer0.<>p__Site2 == null)
		{
			Program.<Main>o__SiteContainer0.<>p__Site2 = CallSite<Func<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "whatever", null, typeof(Program), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		arg_CB_0(arg_CB_1, arg_CB_2, Program.<Main>o__SiteContainer0.<>p__Site2.Target(Program.<Main>o__SiteContainer0.<>p__Site2, typeof(Program), param));
