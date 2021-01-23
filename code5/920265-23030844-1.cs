    public abstract class BaseFoo
    {
        private Action toRunOnConstruct;
        public BaseFoo(Action toRunOnConstruct)
        {
            this.toRunOnConstruct = toRunOnConstruct;
            toRunOnConstruct.Invoke();
        }
    }
    public class Foo : BaseFoo
    {
        private Stream _stream;
        public Foo(Stream stream) : base(()=> SomethingToDoWithTheStream(stream))
        {
            _stream = stream;
        }
        public static void SomethingToDoWithTheStream(Stream stream)
        {
            //do anything with the stream
            stream.Read(...);
            //--> _stream = null
        }
