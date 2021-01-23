    public class ClosureClass
    {
        public X var;
        public void method1(Y it)
        {
            Op(var, it);
        }
    }
---
    IEnumerable<Y> ls = null;
    ClosureClass closure = new ClosureClass();
    closure.var = null;
    Parallel.ForEach(ls, closure.method1);
