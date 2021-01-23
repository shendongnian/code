        public class BaseClass<T>
        {
            private List<T> _list = new List<T>();
            public BaseClass()
            {
                Enumerable.Empty<T>();
                // or Enumerable.Repeat(new T(), 10);
                // or even new T();
                // or foreach (var item in _list) {}
            }
            public void Run()
            {
                for (var i = 0; i < 8000000; i++)
                {
                    if (_list.Any())
                    {
                        return;
                    }
                }
            }
            public void Run2()
            {
                for (var i = 0; i < 8000000; i++)
                {
                    if (_list.Any())
                    {
                        return;
                    }
                }
            }
            public void Run3()
            {
                for (var i = 0; i < 8000000; i++)
                {
                    if (_list.Any())
                    {
                        return;
                    }
                }
            }
        }
