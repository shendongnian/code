    // following code uses big UndoUnit
    public void SetGlobalVariable(object v){
        var oldValue = GlobalVariable;
        GlobalVariable = v;
        var action = new UndoUnit{
            UndoAction = ()=>{
                GlobalVariable = oldValue;
            },
            RedoAction = ()=>{
                GlobalVariable = v;
            }
        };
        UndoManager.Add(action);
    }
    /// <summary>
    /// Used to indicates the designer's status 
    /// </summary>
    public enum UndoUnitState
    {
        Undoing,
        Redoing,
    }
    /// <summary>
    /// A UndoUnitBase can be used as a IOleUndoUnit or just a undo step in 
    /// a transaction  
    /// </summary>
    public class UndoUnitBase : IOleUndoUnit
    {
        public Action UndoAction {get;set;}
        public Action RedoAction {get;set;}
        private string name = null;
        private Guid clsid = Guid.Empty;
        private bool inDoAction = false;
        private bool isStillAtTop = true;
        private UndoUnitState unitState = UndoUnitState.Undoing;
        protected UndoUnit UnitState
        {
            get { return unitState; }
            set { unitState = value; }
        }
        /// <summary>
        /// </summary>
        /// <param name="undoManager"></param>
        /// <param name="name"></param>
        internal UndoUnitBase(string name)
        {
            this.name = name;
        }
        ~UndoUnitBase()
        {
        }
        /// <summary>
        /// </summary>
        protected bool InDoAction
        {
            get
            {
                return inDoAction;
            }
        }
        public string UndoName
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public Guid Clsid
        {
            get { return clsid; }
            set { clsid = value; }
        }
        /// <summary>
        /// This property indicates whether the undo unit is at the top (most recently added to)
        /// the undo stack. This is useful to know when deciding whether undo units for operations
        /// like typing can be coallesced together.
        /// </summary>
        public bool IsStillAtTop
        {
            get { return isStillAtTop; }
        }
        /// <summary>
        /// This function do the actual undo, and then revert the action to be a redo 
        /// </summary>
        /// <returns>objects that should be selected after DoAction</returns>
        protected abstract void DoActionInternal();
        /// <devdoc>
        ///     IOleUndoManager's "Do" action.
        /// </devdoc>
        void IOleUndoUnit.Do(IOleUndoManager oleUndoManager)
        {
            Do(oleUndoManager);
        }
        protected virtual int Do(IOleUndoManager oleUndoManager)
        {
            try
            {
                if(unitState== UndoUnitState.Undoing){
                     UndoAction();
                }else{
                     RedoAction();
                }
                unitState = (unitState == UndoUnitState.Undoing) ? UndoUnitState.Redoing : UndoUnitState.Undoing;
                if (oleUndoManager != null)
                    oleUndoManager.Add(this);
                return VSConstants.S_OK;
            }
            catch (COMException e)
            {
                return e.ErrorCode;
            }
            catch
            {
                return VSConstants.E_ABORT;
            }
            finally
            {
            }
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        void IOleUndoUnit.GetDescription(out string pBstr)
        {
            pBstr = name;
        }
        /// <summary>
        /// </summary>
        /// <param name="clsid"></param>
        /// <param name="pID"></param>
        /// <returns></returns>
        void IOleUndoUnit.GetUnitType(out Guid pClsid, out int plID)
        {
            pClsid = Clsid;
            plID = 0;
        }
        /// <summary>
        /// </summary>
        void IOleUndoUnit.OnNextAdd()
        {
            // We are no longer the top most undo unit; another one was added.
            isStillAtTop = false;
        }
    }
    public class MyUndoEngine : UndoEngine, IUndoHandler
        {                
                Stack<UndoEngine.UndoUnit> undoStack = new Stack<UndoEngine.UndoUnit>();
                Stack<UndoEngine.UndoUnit> redoStack = new Stack<UndoEngine.UndoUnit>();
                
                public ReportDesignerUndoEngine(IServiceProvider provider) : base(provider)
                {
                }
                
                #region IUndoHandler
                public bool EnableUndo {
                        get {
                                return undoStack.Count > 0;
                        }
                }
                
                public bool EnableRedo {
                        get {
                                return redoStack.Count > 0;
                        }
                }                
                public void Undo()
                {
                        if (undoStack.Count > 0) {
                                UndoEngine.UndoUnit unit = undoStack.Pop();
                                unit.Undo();
                                redoStack.Push(unit);
                        }
                }
                
                public void Redo()
                {
                        if (redoStack.Count > 0) {
                                UndoEngine.UndoUnit unit = redoStack.Pop();
                                unit.Undo();
                                undoStack.Push(unit);
                        }
                }
                #endregion
                
                protected override void AddUndoUnit(UndoEngine.UndoUnit unit)
                {
                        undoStack.Push(unit);
                }
        }
