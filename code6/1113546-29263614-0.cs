        using System;
        using System.Collections.Generic;
        using System.Reflection;
        
        class Program
        {
            static void Main(string[] args)
            {
                ManagerClass.BaseClass dc = new DerivedClass();
                ManagerClass.BaseClass adc = new AnotherDerivedClass();
                
                // Is accessible from outside ManagerClass
                dc.IsRunning = true;
                
                // Is not accessible from outside ManagerClass
                // dc.DoStuff();
        
                ManagerClass.TestManager();
        
                // Wait for input.
                Console.ReadKey(true);
            }
        }
        
        class ManagerClass
        {
            static ManagerClass instance;
            static List<BaseClass> managedList = new List<BaseClass>();
            static MethodInfo doStuffMethod = typeof(BaseClass).GetMethod("DoStuff", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.ExactBinding);
            static MethodInfo doOtherStuffMethod = typeof(BaseClass).GetMethod("DoOtherStuff", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.ExactBinding);
        
            public static ManagerClass Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ManagerClass();
                    }
        
                    return instance;
                }
            }
        
            public static void TestManager()
            {
                for (int i = 0; i < managedList.Count; i++)
                {
                    // DoStuff() and DoOtherStuff need to be accessible only from the ManagerClass.
                    // Invocation of the virtual methods calls the derived methods.
                    doStuffMethod.Invoke(managedList[i], null);
                    doOtherStuffMethod.Invoke(managedList[i], null);
                }
            }
        
            public abstract class BaseClass
            {
                public BaseClass()
                {
                    Console.WriteLine("BaseClass()");
                    managedList.Add(this);
        
                    // All of ManagerClass fields are accessible from here:
                    // instance, managedList, etc.
                }
        
                public bool IsRunning { get; set; }
        
                protected virtual void DoStuff()
                {
                    Console.WriteLine("BaseClass.DoStuff()");
                }
        
                protected abstract void DoOtherStuff();
            }
        }
        
        class DerivedClass : ManagerClass.BaseClass
        {
            public DerivedClass()
            {
                Console.WriteLine("DerivedClass()");
        
                // None of the ManagerClass fields are accessible from classes deriving from BaseClass:
                // instance, managedList, etc.
            }
        
            protected override void DoStuff()
            {
                Console.WriteLine("DerivedClass.DoStuff()");
            }
        
            protected override void DoOtherStuff()
            {
                Console.WriteLine("DerivedClass.DoOtherStuff()");
            }
        }
        
        class AnotherDerivedClass : ManagerClass.BaseClass
        {
            public AnotherDerivedClass()
            {
                Console.WriteLine("AnotherDerivedClass()");
            }
        
            protected override void DoStuff()
            {
                Console.WriteLine("AnotherDerivedClass.DoStuff()");
            }
        
            protected override void DoOtherStuff()
            {
                Console.WriteLine("AnotherDerivedClass.DoOtherStuff()");
            }
        }
        
