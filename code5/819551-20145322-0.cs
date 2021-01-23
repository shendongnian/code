    using System;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public Interface ITextContent
            {
               string GetContent();
            }
            public class ClassA : ITextContent
            {
                public string Xml
                {
                    get { return "xml"; }
                }
                public string GetContent()
                {
                    return this.Xml;
                }
            }
    
            public class ClassB : ITextContent
            {
                public char Text
                {
                    get { return 't'; }
                }
                public string GetContent()
                {
                    return this.Text;
                }
            }
    
            public interface IReturnArgs<out T>
            {
                string Name { get; set; }
                T Source { get; }
            }
    
            public class ReturnArgs<T> : IReturnArgs<T>
                where T : class
            {
                public string Name { get; set; }
    
                private T _source;
    
                public T Source
                {
                    get { return _source ?? (_source = (T) Activator.CreateInstance(typeof (T), new object[] {})); }
                }
            }
    
            private static void Main(string[] args)
            {
                var classA = new ReturnArgs<ClassA>();
                var classB = new ReturnArgs<ClassB>();
    
                var xml = new ClassContent();
                xml.Execute(classA);
    
                var text = new ClassContent();
                text.Execute(classB);
    
                Console.ReadKey();
            }
    
            public class ClassContent
            {
                public void Execute(IReturnArgs<object> args)
                {
                    Print(args);
                }
    
                public void Print(IReturnArgs<object> args)
                {
                    Console.WriteLine(((IReturnArgs<ITextContent>)args).GetContent());
                }
            }
        }
    }
