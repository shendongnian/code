    public class MyEnumType : EnumMappingBase
    {
        public MyEnumType()
            : base(typeof(MyEnum))
        {}
        public override object GetInstance(object code)
        {
            // Set the desired default value
            MyEnum instanceValue = MyEnum.Enum1;
            Enum.TryParse(code, true, out instanceValue);
            return instanceValue;    
        }
    }
