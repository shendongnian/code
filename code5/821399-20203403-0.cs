    using Test1;
    namespace NotTest1
    {
    class Class1 {
        Form1 _parent;
        public Class1(Form1 parent) {
            _parent = parent;
        }
        public void Function1()
        {
           // Do lots of "stuff"
            _parent.Form1Function("Got Here");
        }
    }
}  
