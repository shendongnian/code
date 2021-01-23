    using System.Text;
    using System.Threading.Tasks;
    
    namespace CsharpFun
    {
        class Program
        {
            static void Main(string[] args)
            {
                Object obj = (Object) new Cool().Jello();
            }
        }
    
        interface ICool<T> where T : IObject
        {
            T Jello();
        }
    
        interface IObject
        {
            
        }
    
        class Cool : ICool<Object>
        {
            public Object Jello() { return new Object(); }
        }
    
        class Object : IObject
        {
    
        }
    }
