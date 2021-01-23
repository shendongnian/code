     public class ClassObject
        {
            public int entier;
    
            public ClassObject(int p_Initial)
            {
                this.entier = p_Initial;
            }
        }
            ClassObject obj1 = new ClassObject(2);
            Console.WriteLine(obj1.entier); ==> Console obj1.entier = 2
            ClassObject obj2 = obj1;
            obj2.entier = 5;
            Console.WriteLine(obj1.entier); ==> Console obj1.entier = 5
            Console.WriteLine(obj2.entier); ==> Console obj2.entier = 5
