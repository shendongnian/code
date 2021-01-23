    public class X {
        public string a = "foo";
        public virtual x(){
            return this.a
        }
    }
    public class Y: X{
       
         public Y()
         {
            a = "bar"; // USE THE BASE CLASS [a], AND ASSIGN TO IT DESIRED STRING
         }
         ......
    }
