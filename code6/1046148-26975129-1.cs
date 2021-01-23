    public class X {
        public virtual string A { get { return "foo"; } }
        public virtual x(){
            return this.A;
        }
    }
    public class Y: X{
        public override string A { get { return "bar"; } }
    }
