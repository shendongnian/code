    interface IGoBackAndForth { void back(); }
    
    public class A : Form, IGoBackAndForth { }
    public class C : ..., IGoBackAndForth { }
    public void go(Object obj)
    {
       var baf = object as IGoBackAndForth;
       if (baf != null) baf.back();
    }
