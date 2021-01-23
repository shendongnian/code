    public class MyItem : ToolStripMenuItem
    {
        public MyItem(string text)
            : base(text)
        {
        }
        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return new MyAccessibleItem(this);
        }
        // unfortunately we can't just derive from ToolStripMenuItemAccessibleObject
        // which is stupidly marked as internal...
        private class MyAccessibleItem : ToolStripDropDownItemAccessibleObject
        {
            public MyAccessibleItem(ToolStripMenuItem owner)
                :base(owner)
            {
                Owner = owner;
            }
            public ToolStripMenuItem Owner { get; private set; } 
            public override AccessibleStates State
            {
                get
                {
                    if (!Owner.Enabled)
                        return base.State;
                    AccessibleStates state = base.State;
                    if ((state & AccessibleStates.Pressed) == AccessibleStates.Pressed)
                    {
                        state &= ~AccessibleStates.Pressed;
                    }
                    
                    if (Owner.Checked)
                    {
                        state |= AccessibleStates.Checked;
                    }
                    return state;
                }
            }
            public override string KeyboardShortcut
            {
                get
                {
                    return Owner.ShortcutKeyDisplayString;
                }
            }
        }
    }
