    public class Demo {
        protected bool branch;
        protected void demo1 (int) {}
        protected void demo1 () {}
        protected void demo2 () {}
        public Action DoesntWork() {
            return branch ? demo1 : demo2; //Error
            return demo1; //ok
        }
    }
