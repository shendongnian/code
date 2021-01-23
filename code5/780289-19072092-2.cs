    // use like
    string desc = myEnum.P.GetAttr().Desc;
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnumAttr : System.Attribute
    {
        public EnumAttr()
        {
        }     
    }
    
    public static class EnumExtension
    {
        public static EnumAttr GetAttr(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var atts = (EnumAttr[])fieldInfo.GetCustomAttributes(typeof(EnumAttr), false);
            return atts.Length > 0 ? atts[0] : null;
        }
        public static myEnumAttr GetAttr(this myEnum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            var atts = (myEnumAttr[])fieldInfo.GetCustomAttributes(typeof(myEnumAttr), false);
            return atts.Length > 0 ? atts[0] : null;
        }
    }
    
    public class myEnumAttr : EnumAttr
    {
        public string Desc { get; set; }
        
        int bt;
        int Qp;
        int lp;
    
        public myEnumAttr(String desc, int bt, int Qp, int lp) {
            this.Desc = desc;
            this.bt = bt;
            this.Qp = Qp;
            this.lp = lp;
        }
    } 
    
    public enum myEnum
    {
        [myEnumAttr("aco", 1000, 4, 8)]P, 
        [myEnumAttr("acs", 2100, 1, 9)]L,
        [myEnumAttr("acn", 3500, 1, 6)]S, 
        [myEnumAttr("ach", 5400, 1, 6)]H,
    }
