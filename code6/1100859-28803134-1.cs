    class O {
        public virtual void DoSomething() {
            // do smtgh in the 'O' case
        }
    }
    class A : O {
        public override void DoSomething() {
            // do smtgh in the 'A' case
        }
    }
    class B : A {
        public override void DoSomething() {
            // do smtgh in the 'B' case
        }
    }
