    public abstract class ControlBase
    {
        protected ControlBase() { }      
        public ControlBase(string name)
        {
            this.name = name;
        }
        public abstract string DisplayMe();        
        protected string name;
    }
    public class ControlA : ControlBase
    {
        public ControlA() { }
        public ControlA(string name, int val) : base(name) { this.val = val; }
        
        int val;
        public override string DisplayMe()
        {
            return val.ToString();
        }
    }
    public class ControlB : ControlBase
    {
        public ControlB(string name, double val) : base(name) { this.val = val; }
        double val;
        public override string DisplayMe()
        {
            return val.ToString();
        } 
    }
    public abstract class XMLBase
    {
        public string Name {get; set;}
             
        public abstract ControlBase ToControl();
    }
    public class XMLA : XMLBase
    {
        public override ControlBase ToControl()
        {
            return new ControlA(Name, Val);
        }
        public int Val {get; set;}
    }
    public class XMLB : XMLBase
    {       
        public override ControlBase ToControl()
        {
            return new ControlB(Name, Val);
        }
        public double Val {get; set;}
    }
    public class Client
    {
        public static void Run()
        {
            IList<XMLBase> xmlList = new List<XMLBase>();
            xmlList.Add(new XMLA() { Name = "minion1", Val = 1 });
            xmlList.Add(new XMLB() { Name = "minion2", Val = 1.232323 });
            IList<ControlBase> controls = new List<ControlBase>();
            foreach (var xmlItem in xmlList)
            {
                var ctrl = xmlItem.ToControl();
                controls.Add(ctrl);
            }
            foreach (ControlBase ctrlBase in controls)
            {
                Console.Out.WriteLine(ctrlBase.DisplayMe());
            }
        }
    }
