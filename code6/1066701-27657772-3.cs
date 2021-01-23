    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Tester
    {
        //declare common functionality
            public interface ISharedFunctionality 
            {
                //put all shared functionality here
                void SomeMethod();
                void SomeOtherMethod();
                void DifferentMethod();
                string Name {get;set;}
            }
            public interface ISinglePlayerFunctionality : ISharedFunctionality
            {
                //put single player functionality here
                void SomeOtherMethod();
                void SomeMethod();
            }
            public interface IMultiplePlayerFunctionality : ISharedFunctionality
            {
                //put multiplayer functionality here
                void DifferentMethod();
                void SomeMethod();
            }
            public class ImplementationBase : ISharedFunctionality
            {
                //shared implementation here
                public void SomeMethod()
                {
                    //do stuff
                    Console.WriteLine("In Base");
                }
                public void SomeOtherMethod()
                {
                    //one you don't want to inherit in multiplayer
                    Console.WriteLine("In Base");
                }
                public void DifferentMethod() 
                {
                    Console.WriteLine("In Base");
                }
                public string Name
                {
                    get;
                    set;
                }
            }
            public class MultiPlayerImplementation : ImplementationBase, IMultiplePlayerFunctionality
            {
                //multiplay impl
                // you inherit some method but don't want to inherit 
                //SomeOtherMethod when cast to ISharedFunctionality
                void ISharedFunctionality.SomeMethod()
                {
                    //when cast to ISharedFunctionality this method will execute not inherited
                    Console.WriteLine("In MutilPlayImplementation");
                } 
            }
            public class SinglePlayerImplementation : ImplementationBase , ISinglePlayerFunctionality
            {
                //singleplay impl
                void ISharedFunctionality.SomeOtherMethod()
                {
                    Console.WriteLine("In SinglePlayerImplementation" );
                }
            }
            public class Factory 
            {
                //logic to decide impl here
                public ISharedFunctionality Create(int numberOfPlayer)
                {
                    if (numberOfPlayer == 1)
                    {
                        return new SinglePlayerImplementation();
                    }
                    else if(numberOfPlayer > 1)
                    {
                        return new MultiPlayerImplementation();
                    }
                    return null;
                }
            }
        class Program
        {
            static void Main(string[] args)
            {
                var factory = new Factory();
                var results = new[]{factory.Create(1) , factory.Create(2) };
                int j=0;
                foreach (var i in results) 
                {
                    ///for single player will be base
                    ///multiplaryer will be mutliplayer
                    i.SomeMethod();
                    //for single player will be single player
                    // for multiplayer will be base
                    i.SomeOtherMethod();
                    i.DifferentMethod();
                    i.Name = "Item-Number-" + j;
                    Console.WriteLine();
                }
            }
        }
    }
