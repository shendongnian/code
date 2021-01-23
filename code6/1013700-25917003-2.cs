    public class Stuff {
        IFoo _foo;
        IBar _bar;
        public Stuff(IFoo foo, IBar bar){
            _foo = foo;
            _bar = bar;
        }
        public void DoStuff() {
            if(_foo.HasFooage) {
                _bar.Bar = 4;
            }
        }
    }
