    public class TestMethodInfo
    {
        public static void Main()
        {
            // Get the constructor and create an instance of MagicClass
    
            String stringedClass = "MagicClass";
            String stringedClassMethod = "theMethod";
            Type magicType = Type.GetType(stringedClass);
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[]{});
    
            // Get the ItsMagic method and invoke with a parameter value of 100
    
            MethodInfo magicMethod = magicType.GetMethod(stringedClassMethod);
            object magicValue = magicMethod.Invoke(magicClassObject, new object[]{100});
    
            Console.WriteLine("MethodInfo.Invoke() Example\n");
            Console.WriteLine("MagicClass.theMethod() returned: {0}", magicValue);
        }
    }
