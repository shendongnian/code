    [Serializable]
    [IntroduceInterface(typeof(ICursorProperty))]
    public class CursorPropertyTypeAttribute : TypeLevelAspect, ICursorProperty, IAdviceProvider, IInstanceScopedAspect
    {
        public Property<Cursor> Cursor;
        Cursor ICursorProperty.Cursor { get { return Cursor.Get(); } set { Cursor.Set(value); } }
        public IEnumerable<AdviceInstance> ProvideAdvices( object targetElement )
        {
            yield return new ImportLocationAdviceInstance(this.GetType().GetField("Cursor", BindingFlags.Public | BindingFlags.Instance), this.FindCursorProperty((Type)targetElement));
        }
        public LocationInfo FindCursorProperty(Type targetType)
        {
            foreach ( PropertyInfo property in targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance) )
            {
                if ( null != property.GetCustomAttribute( typeof(CursorPropertyAttribute) ) )
                    return new LocationInfo( property );
            }
            return null;
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
    public interface ICursorProperty
    {
        Cursor Cursor { get; set; }
    }
    [Serializable]
    [AspectTypeDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, typeof(CursorPropertyTypeAttribute))]
    public class ChangeCursorAttribute : OnMethodBoundaryAspect, IAspectProvider
    {
        private string cursorName;
        [NonSerialized]
        private Cursor cursor; 
        public ChangeCursorAttribute( string cursorName )
        {
            this.cursorName = cursorName;
        }
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            Type type = ((MethodBase) targetElement).DeclaringType;
            IAspectRepositoryService repository = PostSharpEnvironment.CurrentProject.GetService<IAspectRepositoryService>();
            if ( !repository.HasAspect( type, typeof(CursorPropertyTypeAttribute) ) )
                yield return new AspectInstance( type, new CursorPropertyTypeAttribute() );
        }
        public override void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo )
        {
            if ( null == typeof(Cursors).GetProperty( this.cursorName, BindingFlags.Public | BindingFlags.Static ) )
                MessageSource.MessageSink.Write( new Message( MessageLocation.Of( method ), SeverityType.Error, "USR001", "Invalid cursor name", null, "MyComponent",
                    null ) );
        }
        public override void RuntimeInitialize( MethodBase method )
        {
            this.cursor = (Cursor) typeof(Cursors).GetProperty( this.cursorName, BindingFlags.Public | BindingFlags.Static ).GetValue( null );
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            (args.Instance as ICursorProperty).Cursor = cursor;
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            (args.Instance as ICursorProperty).Cursor = Cursors.DefaultCursor;
        }
    }
