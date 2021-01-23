    public abstract class MyBaseClass
    {
        public virtual void FunctionCall(int i)
        {
            this.FunctionCall(i, "");
        }
        public virtual void FunctionCall(int i, string s)
        {
        }
    }
    public class MyDerivedClass : MyBaseClass
    {
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
    }
