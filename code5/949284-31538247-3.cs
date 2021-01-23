    private static void Main(string[] args)
    {
      Base base1 = (Base) Program.GetChild();
      if (Program.<Main>o__SiteContainer0.<>p__Site1 == null)
        Program.<Main>o__SiteContainer0.<>p__Site1 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Test", (IEnumerable<Type>) null, typeof (Program), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      Program.<Main>o__SiteContainer0.<>p__Site1.Target((CallSite) Program.<Main>o__SiteContainer0.<>p__Site1, typeof (Program), (object) base1);
      Base base2 = Program.GetBase();
      if (Program.<Main>o__SiteContainer0.<>p__Site2 == null)
        Program.<Main>o__SiteContainer0.<>p__Site2 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Test", (IEnumerable<Type>) null, typeof (Program), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      Program.<Main>o__SiteContainer0.<>p__Site2.Target((CallSite) Program.<Main>o__SiteContainer0.<>p__Site2, typeof (Program), (object) base2);
    }
