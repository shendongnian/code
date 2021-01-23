        // The [DebuggerHiddenAttribute] makes debugger stop
        // on the actual DebugEx.Assert(...) call, rather than inside 
        // the DebugEx.Assert(...) method itself.
        [DebuggerHiddenAttribute]
        public static void Assert(bool condition)
        {
            if (Debugger.IsAttached)
            {
                if (!condition)
                {
                    Debugger.Break();
                }
            }
            else
            {
                Debug.Assert(condition);
            }
        }
