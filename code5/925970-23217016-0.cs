    public class BaseClass
    {
        public BaseClass()
        {
        }
        public virtual BaseClass ShallowCopy()
        {
            return new BaseClass();
        }
    
        public virtual string GetMSG()
        {
            return "Base";
        }
    }
    public class DrivenClass : BaseClass
    {
        public string MSG { get; set; }
    
        public DrivenClass(string msg)
        {
            MSG = msg;
        }
    
        public override BaseClass ShallowCopy() {
            return new DrivenClass(this.MSG);
        }
    
        public override string GetMSG()
        {
            return  MSG;
        }
    }
