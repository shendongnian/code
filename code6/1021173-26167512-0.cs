    public class Class10: Class1 {
        public class Letter {
            readonly Class10 parent;
            public Letter(Class10 parent) {
                this.parent = parent;
            }
            public void FunctionA() {
                parent.globalPrinter.print(parent.A);
            }
        }
    }
