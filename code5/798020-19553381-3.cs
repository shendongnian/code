        //User's algorithm pattern.
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
