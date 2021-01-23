    public class XMLBase
    {
        string name;
    
        public virtual ControlBase ToControl()
        {
           return new ControlBase(name);
        }
    }
    public class XMLA : XMLBase
    {
        int val;
    
        public override ControlBase ToControl()
        {
           return new ControlA(name, val);
        }
    }
    public class XMLB : XMLBase
    {
        double val;
    
        public override ControlBase ToControl()
        {
           return new ControlB(name, val);
        }
    }
