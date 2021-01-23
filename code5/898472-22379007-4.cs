    using System;
    using System.Linq;
    using System.Timers;
    public static class Program
    {
        public static void Main()
        {
            IEnumerable<Type> assemblyTypes = typeof(MonoBehaviour).Assembly.GetTypes();
            IEnumerable<Type> behaviourTypes = assemblyTypes
                .Where(type => typeof(MonoBehaviour).IsAssignableFrom(type))
                .Where(type => !type.IsAbstract);
            List<MonoBehaviour> behaviours = behaviourTypes
                .Select(Activator.CreateInstance)
                .Cast<MonoBehaviour>()
                .ToList();
            foreach (MonoBehaviour monoBehaviour in behaviours)
            {
                monoBehaviour.Start();
            }
            var timer = new Timer(10 /* Milliseconds */);
            timer.Elapsed += (sender, eventArgs) =>
            {
                foreach (MonoBehaviour monoBehaviour in behaviours)
                {
                    monoBehaviour.Update();
                }
            };
            timer.Start();
            Console.WriteLine("Press a key to stop.");
            Console.ReadKey();
        }
    }
    public abstract class MonoBehaviour
    {
        public virtual void Start()
        {
        }
        public virtual void Update()
        {
        }
        protected static void Log(string message)
        {
            Console.WriteLine("{0} - {1}", DateTime.Now, message);
        }
    }
    public class Behaviour1 : MonoBehaviour
    {
        public override void Start()
        {
            Log("Behaviour1 - Start");
        }
        public override void Update()
        {
            Log("Behaviour1 - Update");
        }
    }
    public class Behaviour2 : MonoBehaviour
    {
        public override void Start()
        {
            Log("Behaviour2 - Start");
        }
        public override void Update()
        {
            Log("Behaviour2 - Update");
        }
    }:
