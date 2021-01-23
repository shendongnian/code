    class BaseDecorator : Base
    {
        Base _baseType;
    
        public BaseDecorator(Base baseType)
        {
            _baseType = baseType;
        {
    
        public override string GetName()
        {
            return _baseType.GetName() + "XX";
        }
    }
