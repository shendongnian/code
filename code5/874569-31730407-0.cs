    [Serializable]
    public sealed class UnitOfWorkContext: MarshalByRefObject, IDisposable, INotifyWhenDisposed
    {
        private const string CallContextCurrentContextKey = "DynaFileIocUnitOfWork";
        private bool _isDisposed;
        private readonly UnitOfWorkContext _priorContext;
        public event EventHandler Disposed;
    
        private UnitOfWorkContext()
        {
            this.Disposed += (sender, ev) => { };
            _priorContext = Current;
            Current = this;
        }
		
        /// <summary>
        /// Creates a new unit of work context, which must be disposed when is finished.
        /// </summary>
		public static IDisposable Create(){
			return new UnitOfWorkContext();
		}
    
        /// <summary>
        /// Gets or sets the current unit of work context.
        /// </summary>
        public static UnitOfWorkContext Current
        {
            get
            {
                return CallContext.LogicalGetData(CallContextCurrentContextKey) as UnitOfWorkContext;                
            }
            private set
            {
                if (ReferenceEquals(value, null))
                {
                    CallContext.FreeNamedDataSlot(CallContextCurrentContextKey);
                }
                else
                {
                    CallContext.LogicalSetData(CallContextCurrentContextKey, value);
                }
            }
        }
    
        /// <summary>
        /// Returns true if the context was disposed.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return _isDisposed;
            }
        }
    
        public void Dispose()
        {
            if(!_isDisposed){
                _isDisposed = true;
                Current = _priorContext;
                // inform Ninject to dispose of all the resolves bound to this scope
                this.Disposed(this, new EventArgs());
            }
        }
    }
