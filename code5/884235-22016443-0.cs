    namespace CSharpLayer
    {
    class Program : CLILayer.CLIObject
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.invokeJava();
        }
        public void invokeJava()
        {
            //Call into CLI layer function to loadJVM, call Java code, etc
            loadJava();
        }
        public override void callback(string data)
        {
            //This will be called from the CLI Layer.
        }
    }
    }
