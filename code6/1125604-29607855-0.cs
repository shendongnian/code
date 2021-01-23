    public class UpdatingEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
    
    public class UpdatedEventArgs : EventArgs
    {
        public int Id { get; set; }
        public int NewValue { get; set; }
    }
    
    
    public class GameObject
    {
        public event EventHandler<UpdatingEventArgs> OnUpdating;
        public event EventHandler<UpdatedEventArgs> OnUpdated;
    
        public int Id { get; set; }
        public int Value { get; set; }
    
        public void Update()
        {
            var updatingHandler = OnUpdating;
            if (updatingHandler != null)
            {
                updatingHandler(this, new UpdatingEventArgs {Id = Id});
            }
    
            if (Value > 0)
            {
                return;
            }
    
            Value++;
    
            var updatedHandler = OnUpdated;
            if (updatedHandler != null)
            {
                updatedHandler(this, new UpdatedEventArgs {Id = Id, NewValue = Value});
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var gameObjects = Enumerable.Range(0, 100)
                .Select(x => new GameObject
                {
                    Id = x, 
                    Value = r.Next(-10, 10)
                })
                .ToList();
    
            var updatingCounter = 0;
            var updatedCounter = 0;
    
            gameObjects.ForEach(x => x.OnUpdating += (sender, arg) => updatingCounter++);
            gameObjects.ForEach(x => x.OnUpdated += (sender, arg) => updatedCounter++);
    
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update();
            }
    
            Console.WriteLine(updatingCounter);
            Console.WriteLine(updatedCounter);
            Console.ReadKey();
        }
    }
