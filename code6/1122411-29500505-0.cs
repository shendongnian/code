    namespace EnumNamespace
    {
        public enum Stuff
        {
            a, b, c
        }
    }
    public class RuleManager
    {
        public EnumNamespace.Stuff Stuff()
        {
            return EnumNamespace.Stuff.a;
        }
        public int BizRule()
        {
            EnumNamespace.Stuff currStuff = Stuff();
            return 1; //who cares, just proving a point
        }
    }
