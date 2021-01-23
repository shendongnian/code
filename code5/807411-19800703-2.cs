    public class MyDerivedClass : MyBaseClass
    {
        public override void FunctionCall(int i, string s = "") 
        {
            if (!string.IsNullOrEmpty(s))
                MessageBox.Show(i.ToString());
            else
               // handle other path here
        }
    }
