    using System;
    using System.Reflection;
    namespace CustomAttributes
    {
        [AttributeUsage(AttributeTargets.Field)]
        public class ConstructableEnumAttribute : Attribute
        {
            public Type Type { get; set; }
            public ConstructableEnumAttribute(Type type)
            {
                this.Type = type;
            }
        }
        public static class AnimalExtension
        {
            public static object Construct(this Animal ofAnimal)
            {
                object animal = null;
                Type typeOfAnimal = GetType(ofAnimal);
                if ((null != typeOfAnimal) &&
                    (!typeOfAnimal.IsAbstract))
                {
                    animal = Activator.CreateInstance(typeOfAnimal);
                }
                return animal;
            }
            private static Type GetType(Animal animal)
            {
                ConstructableEnumAttribute attr = (ConstructableEnumAttribute)
                    Attribute.GetCustomAttribute
                    (ForValue(animal), typeof(ConstructableEnumAttribute));
                return attr.Type;
            }
            private static MemberInfo ForValue(Animal animal)
            {
                return typeof(Animal).GetField(Enum.GetName(typeof(Animal), animal));
            }
        }
        public enum Animal
        {
            [ConstructableEnum(typeof(Cat))]
            Cat,
            [ConstructableEnum(typeof(Dog))]
            Dog,
            [ConstructableEnum(typeof(Cow))]
            Cow,
            [ConstructableEnum(typeof(Pigeon))]
            Pigeon
        }
        public class Cat
        { }
        public class Dog
        { }
        public class Cow
        { }
        public class Pigeon
        { }
        public class Owner
        {
            Animal pet;
            Owner(Animal animal)
            {
                pet = animal;
            }
            public void ShowPet()
            {
                object theCreature = pet.Construct();
                Console.WriteLine("My pet is a " + theCreature.GetType().ToString());
            }
        }
    }
