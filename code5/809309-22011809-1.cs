    public partial class NonFlickerSplitContainer : SplitContainer
    {
        public NonFlickerSplitContainer()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle",BindingFlags.NonPublic|BindingFlags.Instance);
            object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                              ControlStyles.UserPaint |
                                              ControlStyles.OptimizedDoubleBuffer, true };
            objMethodInfo.Invoke(this.Panel1, objArgs);
            objMethodInfo.Invoke(this.Panel2, objArgs);
        }
    }
