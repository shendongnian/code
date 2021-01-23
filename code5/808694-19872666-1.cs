    public class WatchedClassViaInheritance : WatchedClass
    {
        public void Print()
        {
            Console.WriteLine(this.WatchDogService.WatchingType.Name);
        }
    }
