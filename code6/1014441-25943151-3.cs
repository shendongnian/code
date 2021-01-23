        public interface IDataStorage
        {
            void Store(string key, string value);
        }
        public class DataStorage : IDataStorage
        {
            public void Store(string key, string value)
            {
                //some usefull logic
            }
        }
