    using System;
    using System.Reflection;
    
    public class MyClass
    {
        public string myFieldA;
        public string myFieldB; 
        public MyClass()
        {
            myFieldA = "A public field";
            myFieldB = "Another public field";
        }
    }
    
    public class FieldInfo_GetValue
    {
        public static void Main()
        {
            MyClass myInstance = new MyClass();
            // Get the type of MyClass.
            Type myType = typeof(MyClass);
            try
            {
                // Get the FieldInfo of MyClass.
                FieldInfo[] myFields = myType.GetFields(BindingFlags.Public 
                    | BindingFlags.Instance);
                // Display the values of the fields.
                Console.WriteLine("\nDisplaying the values of the fields of {0}.\n",
                    myType);
                for(int i = 0; i < myFields.Length; i++)
                {
                    Console.WriteLine("The value of {0} is: {1}",
                        myFields[i].Name, myFields[i].GetValue(myInstance));
                }
            }  
            catch(Exception e)
            {
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }
    }
