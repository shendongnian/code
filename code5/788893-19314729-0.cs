    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    class Program
    {
        static void Main(string[] args)
        {
            dynamic ent = new Entity();
            ent.Components.Add(new Transform() { X = 5, Y = 8 });
            Console.WriteLine(ent.Transform.X);
            ent.Transform.X = 12;
            Console.WriteLine(ent.Transform.X);
            Console.ReadKey();
        }
    }
    class Entity : DynamicObject
    {
        public List<Component> Components = new List<Component>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            for (int i = 0; i < Components.Count; i++)
            {
                Component component = Components[i];
                if (component.GetType().Name == binder.Name)
                {
                    result = component;
                    return true;
                }
            }
            result = null;
            return false;
        }
    }
    class Component
    {
    }
    class Transform : Component
    {
        public float X;
        public float Y;
    }
