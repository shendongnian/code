    class Program
    {
        static void Main(string[] args)
        {
            IAlgorithm algo = new Algorithm();
            Dictionary<Type, string[]> userDataSources = new Dictionary<Type, string[]>();
            userDataSources.Add(typeof(Weather), new string[] { "temperature data1", "temperature data2" });
            for (int i = 0; i < 2; i++)
            {
                foreach (Type t in userDataSources.Keys)
                {
                    string line = userDataSources[t][i]; //Iterate over CSV data..
                    var userObj = Activator.CreateInstance(t);
                    UserData castObj = (UserData)userObj;
                    castObj.Constuctor(line);
                    algo.OnData(castObj);
                }
            }
        }
        interface IAlgorithm
        {
            void OnData(object data);
        }
        abstract class BaseAlgorithm<TData> : IAlgorithm where TData : class 
        {
            public void OnData(object data) 
            {
                //perform type checks here, if necessary
                OnData(data as TData);
            }
            protected abstract void OnData(TData data);
        }
        //User's algorithm.
        class Algorithm : BaseAlgorithm<Weather>
        {
            //Handle Custom User Data
            protected override void OnData(Weather data)
            {
                Console.WriteLine(data.date.ToString());
                Console.ReadKey();
            }
        }
        public abstract class UserData {
            public DateTime date;
            public UserData() { }
            public abstract void Constuctor(string line);
        }
        public class Weather : UserData 
        {
            public DateTime date = new DateTime();
            public double temperature = 0;
            public Weather() { }
            public override void Constuctor(string line) {
                Console.WriteLine("Initializing weather object with: " + line);
                date = DateTime.Now;
                temperature = -1;
            }
        }
    }
