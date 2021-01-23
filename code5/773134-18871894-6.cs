    public class Persistent
    {
        public virtual Persistent Clone()
        {
			if(GetType() == typeof(Persistent))
			return new Persistent();
			var o = Activator.CreateInstance(GetType());
                        // use reflection to copy field values
			return (Persistent)o;
        }
    }
    public class Animal : Persistent
    {
        public new Animal Clone()
        {
			if(GetType() == typeof(Animal)) 
                        {
                            // manually copy field values
			    return new Animal();
                        }
			return (Animal) base.Clone();
        }
    }
    public class Pet : Animal
    {
        public void PetSpecific()
        {
			Console.WriteLine("Pet!");
        }
    }
    public class Wild : Animal
    {
        public new Wild Clone()
        {
			if(GetType() == typeof(Wild))
			{
                            // manually copy field values
			    return new Wild();
                        }
			return (Wild) base.Clone();
        }
    }
    private static void Test6()
    {
        var p = new Persistent().Clone();
        Console.WriteLine("Type of p: {0}", p);
        var a = new Animal().Clone();
        Console.WriteLine("Type of a: {0}", a);
        var t = new Pet().Clone() as Pet;
        Console.WriteLine("Type of t: {0}", t);
        t.PetSpecific();
        var w = new Wild().Clone();
        Console.WriteLine("Type of w: {0}", w);
    }
