    public class TestMethodInfo
    {
        public static void Main()
        {
            // Get the constructor and create an instance of MagicClass
    
            String stringedClass = "MagicClass";
            Type magicType = Type.GetType(stringedClass);
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[]{});
    
            // Get the ItsMagic method and invoke with a parameter value of 100
    
            MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
            object magicValue = magicMethod.Invoke(magicClassObject, new object[]{100});
    
            Console.WriteLine("MethodInfo.Invoke() Example\n");
            Console.WriteLine("MagicClass.ItsMagic() returned: {0}", magicValue);
        }
    }
