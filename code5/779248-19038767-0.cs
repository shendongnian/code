    public static void Main() 
        {
            Type myType =(typeof(MyTypeClass));
            // Get the public methods.
            MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            Console.WriteLine("\nThe number of public methods is {0}.", myArrayMethodInfo.Length);
            // Display all the methods.
            DisplayMethodInfo(myArrayMethodInfo);
            // Get the nonpublic methods.
            MethodInfo[] myArrayMethodInfo1 = myType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.DeclaredOnly);
            Console.WriteLine("\nThe number of protected methods is {0}.", myArrayMethodInfo1.Length);
            // Display information for all methods.
            DisplayMethodInfo(myArrayMethodInfo1);		
        }
        public static void DisplayMethodInfo(MethodInfo[] myArrayMethodInfo)
        {
            // Display information for all methods. 
            for(int i=0;i<myArrayMethodInfo.Length;i++)
            {
                MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
                Console.WriteLine("\nThe name of the method is {0}.", myMethodInfo.Name);
            }
        }
