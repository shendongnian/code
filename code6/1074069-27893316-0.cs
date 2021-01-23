    namespace DLLNamespace
    {
        public struct TestStruct
        {
            public string Name { get; set; }
            public void SetName(string name) { this.Name = name; }
        }
    }
    namespace ProgramNamespace
    {
        public static class ExtensionMethods
        {
            public static void ReverseName(this DLLNamespace.TestStruct target)
            {
                target.Name = new string(target.Name.ToArray().Reverse().ToArray());
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                DLLNamespace.TestStruct ts;
                ts.SetName("John");
                ts.ReverseName();
                Console.WriteLine(ts.Name);
            }
        }
    }
