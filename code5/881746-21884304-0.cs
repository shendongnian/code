        MemberInfo m1 = typeof(Object).GetMethod("ToString");
        MemberInfo m2 = typeof(MemberInfo).GetMethod("ToString");
        Console.WriteLine(m1.DeclaringType); //System.Object
        Console.WriteLine(m1.ReflectedType); //System.Object
        Console.WriteLine(m2.DeclaringType); //System.Object
        Console.WriteLine(m2.ReflectedType); //System.Reflection.MemberInfo
