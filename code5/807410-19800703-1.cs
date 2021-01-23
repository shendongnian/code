    public abstract class MyBaseClass
    {    
        public abstract void FunctionCall(int i);                                        
        public abstract void FunctionCall(int i, string s = "");
    }
    
    public class MyDerivedClass : MyBaseClass
    {
        public override void FunctionCall(int i, string s = "") { }
        public override void FunctionCall(int i)
        {
            MessageBox.Show(i.ToString());
        }
    }
    
    public class YourDerivedClass : MyBaseClass
    {
        public override void FunctionCall(int i, string s)
        {
            MessageBox.Show(s + " " + i.ToString());
        }
        
        public override void FunctionCall(int i) {}
    }
