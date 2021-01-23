    Assembly assembly = Assembly.LoadFrom(sAssemblyFileName)
    IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)).OrderBy(x => x.Name);
    foreach (Type cls in types)
    {
          list.Add(cls.Name.Replace("Controller", ""));
          IEnumerable<MemberInfo> memberInfo = cls.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).OrderBy(x => x.Name);
          foreach (MemberInfo method in memberInfo)
          {
               if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
               {
                      list.Add("\t" + method.Name.ToString());
               }
          }
    }
