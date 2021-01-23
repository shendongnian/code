    class A {
        IB _ib;
        public A(out Func<IA> getter, out Action<IB> setter) {
            getter = CreateIA;
            setter = SetIB;
        }
        void SetIB(IB ib) {
            _ib = ib;
        }
        IA CreateIA() { throw new NotImplementedException(); }
    }
    class B {
        IA _ia;
        public B(out Func<IB> getter, out Action<IA> setter) {
            getter = CreateIB;
            setter = SetIA;
        }
        void SetIA(IA ia) {
            _ia = ia;
        }
        IB CreateIB() { throw new NotImplementedException(); }
    }
.
    class PairMaker {
        public static Tuple<A, B> MakePair() {
            Func<IA> iaGetter;
            Func<IB> ibGetter;
            Action<IA> iaSetter;
            Action<IB> ibSetter;
            A a = new A(out iaGetter, out ibSetter);
            B b = new B(out ibGetter, out iaSetter);
            iaSetter(iaGetter());
            ibSetter(ibGetter());
            return Tuple.Create(a, b);
        }
    }
