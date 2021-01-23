    public class Program
    {
        public void Main()
        {
            First blank = new First();
            First populated = new First(true);
		
            //where a value exists
            int value = NestedProperty<First,int>(blank,f => f.Second.Third.id);
            Console.WriteLine(value);//0
            //where no value exists
            value = NestedProperty<First,int>(populated,f => f.Second.Third.id);
            Console.WriteLine(value);//1
            //where no value exists and a default was used
            value = NestedProperty<First,int>(blank,f => f.Second.Third.id,-1);
            Console.WriteLine(value);//-1
        }
	
        public E NestedProperty<T,E>(T Parent, Func<T,E> Path, E IfNullOrEmpty = default(E))
        {
            try
            {
                return Path(Parent);
            }
            catch
            {
                return IfNullOrEmpty;
            }
        }
    }
