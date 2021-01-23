        using System;
        using System.Collections.Generic;
        
        namespace testapp2
        {
            class Program
            {
                static void Main()
                {
                    ClassA a = ClassA.Instance;
                    ClassB b = ClassB.Instance;
        
                    ManagerClass.TestManager();
        
                    Console.ReadKey(true);
                }
            }
        }
        
        class ManagerClass
        {
            static ManagerClass instance;
            static Dictionary<Type, ManagedClass> managedList = new Dictionary<Type, ManagedClass>();
        
            public ManagerClass Instance
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
        
            ManagerClass()
            {
        
            }
        
            public static void TestManager()
            {
                foreach (var kvp in managedList)
                {
                    kvp.Value.doStuffCallback();
                    kvp.Value.doOtherStuffCallback();
                }
            }
        
            public static void CreateManagedClass(Type type, Action doStuffCallback, Action doOtherStuffCallback)
            {
                managedList.Add(type, new ManagedClass(doStuffCallback, doOtherStuffCallback));
            }
        
            public static void DestroyManagedClass(Type type)
            {
                managedList.Remove(type);
            }
        
            class ManagedClass
            {
                public Action doStuffCallback;
                public Action doOtherStuffCallback;
        
                public ManagedClass(Action doStuffCallback, Action doOtherStuffCallback)
                {
                    this.doStuffCallback = doStuffCallback;
                    this.doOtherStuffCallback = doOtherStuffCallback;
                }
            }
        
            public abstract class ManagedClassBase<T> where T : class, new()
            {
                static T instance;
        
                public static T Instance
                {
                    get
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
        
                        return instance;
                    }
                }
        
                protected ManagedClassBase()
                {
                    CreateManagedClass(typeof(T), DoStuff, DoOtherStuff);
                }
        
                ~ManagedClassBase()
                {
                    instance = null;
                }
        
                protected abstract void DoStuff();
                protected abstract void DoOtherStuff();
            }
        }
        
        class ClassA : ManagerClass.ManagedClassBase<ClassA>
        {
            protected override void DoStuff()
            {
                Console.WriteLine("ClassA.DoStuff()");
            }
        
            protected override void DoOtherStuff()
            {
                Console.WriteLine("ClassA.DoOtherStuff()");
            }
        }
        
        class ClassB : ManagerClass.ManagedClassBase<ClassB>
        {
            protected override void DoStuff()
            {
                Console.WriteLine("ClassB.DoStuff()");
            }
        
            protected override void DoOtherStuff()
            {
                Console.WriteLine("ClassB.DoOtherStuff()");
            }
        }
        
