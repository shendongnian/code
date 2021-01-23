    class Program {
        static void Main(string[] args) {
            //compile error: ISomething must be non-abstract with public
            //               parameterless constructor
            RxQuery<ISomething> something = new RxQuery<ISomething>();
        }
    }
    interface ISomething { };
    interface IRxQuery<T> { }
    public class RxQuery<T> : IRxQuery<T> where T:new() /*, IDeserializableObject*/ {
        //Factory Method Pattern
        protected virtual T Get(/*IDeserializableObject row*/) { return new T(); }
    }
