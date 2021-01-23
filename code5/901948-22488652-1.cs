    public static class TreeViewExtensions
    {
        /// <summary>
        /// Gets a value indicating if the checkbox is visible on the tree node.
        /// </summary>
        /// <param name="node">The tree node.</param>
        /// <returns><value>true</value> if the checkbox is visible on the tree node; otherwise <value>false</value>.</returns>
        public static bool IsCheckBoxVisible(this TreeNode node)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (node.TreeView == null)
                throw new InvalidOperationException("The node does not belong to a tree.");
            var tvi = new TVITEM
                {
                    hItem = node.Handle,
                    mask = TVIF_STATE
                };
            var result = SendMessage(node.TreeView.Handle, TVM_GETITEM, node.Handle, ref tvi);
            if (result == IntPtr.Zero)
                throw new ApplicationException("Error getting TreeNode state.");
            var imageIndex = (tvi.state & TVIS_STATEIMAGEMASK) >> 12;
            return (imageIndex != 0);
        }
        /// <summary>
        /// Sets a value indicating if the checkbox is visible on the tree node.
        /// </summary>
        /// <param name="node">The tree node.</param>
        /// <param name="value"><value>true</value> to make the checkbox visible on the tree node; otherwise <value>false</value>.</param>
        public static void SetIsCheckBoxVisible(this TreeNode node, bool value)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (node.TreeView == null)
                throw new InvalidOperationException("The node does not belong to a tree.");
            var tvi = new TVITEM
                {
                    hItem = node.Handle,
                    mask = TVIF_STATE,
                    stateMask = TVIS_STATEIMAGEMASK,
                    state = (value ? node.Checked ? 2 : 1 : 0) << 12
                };
            var result = SendMessage(node.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
            if (result == IntPtr.Zero)
                throw new ApplicationException("Error setting TreeNode state.");
        }
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_GETITEM = TV_FIRST + 62;
        private const int TVM_SETITEM = TV_FIRST + 63;
        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);
    }
