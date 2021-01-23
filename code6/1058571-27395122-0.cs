    interface ISetValue<in T>
        {
            void SetData(T data);
        }
    
        interface IGetValue<out T>
        {
            T GetData();
        }
    
        class Packaging<T> : ISetValue<T>, IGetValue<T>
        {
            private T storedData;
            void ISetValue<T>.SetData(T data)
            {
                this.storedData = data;
            }
            T IGetValue<T>.GetData()
            {
                return this.storedData;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Packaging<string> stringPackage = new Packaging<string>();
                ISetValue<string> setStringValue = stringPackage;
                setStringValue.SetData("Sample string");
                // the line below causes a compile-time error
                IGetValue<object> getObjectValue = stringPackage;
    
                Console.WriteLine("{0}", getObjectValue.GetData());
            }
        }
