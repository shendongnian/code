    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class CommandTypeAttribute : Attribute
    {
        protected Type fCommandType;
        public CommandTypeAttribute(Type commandType)
        {
            fCommandType = commandType;
        }
        public Type CommandType
        {
            get { return fCommandType; }
            set { fCommandType = value; }
        }
    }
