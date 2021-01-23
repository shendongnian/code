    interface ICanDoSomething {
        void DoSomething();
    }
    class A : ICanDoSomething {
        void DoSomething(){
            //some code
        }
    }
    class B : ICanDoSomething{
        void DoSomething(){
            //some code
        }
    }
    class Controller {
        public ICanDoSomething theObject;
        public void DoSomething(){
            theObject.DoSomething();
        }
    }
    ....
