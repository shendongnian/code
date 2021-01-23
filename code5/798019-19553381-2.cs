        //User's algorithm pattern.
        interface IAlgorithm<TData> where TData : class
        {
            void OnData(TData data);
        }
        //User's algorithm.
        class Algorithm : IAlgorithm<Weather>
        {
            //Handle Custom User Data
            public void OnData(Weather data)
            {
                Console.WriteLine(data.date.ToString());
                Console.ReadKey();
            }
        }
    And the usage in this case would be:
        var userObj = Activator.CreateInstance(type, line);
        algo.OnData((Weather)userObj);
