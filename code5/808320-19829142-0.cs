    using System;
    public class Test
    {
        public static void Main()
        {
            var AnonymousInside = GetAnonymousTyped(GetAnonymousObject(), new {Key="",Value=""});
            Console.Write(AnonymousInside.Key);//All Ok
        }
        public static T GetAnonymousTyped<T>(object o, T _)
        {
            return (T)o;
        }
        public static object GetAnonymousObject()
        {
             return new {Key="KeyName",Value="ValueName"};
        }
    }
