    public abstract class DynamicMetaObjectWrapper : DynamicMetaObject
    {
        public DynamicMetaObjectWrapper(Expression expression, DynamicMetaObject wrappedMetaObject)
            : base(expression, wrappedMetaObject.Restrictions, wrappedMetaObject.Value)
        {
            this.MetaObject = wrappedMetaObject;
        }
        public DynamicMetaObjectWrapper(DynamicMetaObject wrappedMetaObject)
            : this(wrappedMetaObject.Expression, wrappedMetaObject)
        {
        }
        public DynamicMetaObject MetaObject { get; private set; }
        
        public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
        {
            return MetaObject.BindBinaryOperation(binder, arg);
        }
        
        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            return MetaObject.BindConvert(binder);
        }
        public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
        {
            return MetaObject.BindCreateInstance(binder, args);
        }
        
        public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return MetaObject.BindDeleteIndex(binder, indexes);
        }
        
        public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
        {
            return MetaObject.BindDeleteMember(binder);
        }
        
        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return MetaObject.BindGetIndex(binder, indexes);
        }
        
        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            return MetaObject.BindGetMember(binder);
        }
        
        public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
        {
            return MetaObject.BindInvoke(binder, args);
        }
        
        public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            return MetaObject.BindInvokeMember(binder, args);
        }
        
        public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
        {
            return MetaObject.BindSetIndex(binder, indexes, value);
        }
        
        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            return MetaObject.BindSetMember(binder, value);
        }
        
        public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
        {
            return MetaObject.BindUnaryOperation(binder);
        }
        
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return MetaObject.GetDynamicMemberNames();
        }
    }
    public abstract class ProjectedDynamicMetaObjectWrapper<TProvider> : DynamicMetaObjectWrapper where TProvider : class, IDynamicMetaObjectProvider
    {
        public ProjectedDynamicMetaObjectWrapper(Expression expression, Func<Expression, Expression> expressionSelector, TProvider provider)
            : base(expression, provider.GetMetaObject(expressionSelector(expression)))
        {
        }
    }
