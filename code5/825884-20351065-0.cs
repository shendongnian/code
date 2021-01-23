    namespace System.Windows.Forms {
        /// <summary>
        /// Fixes ToolStripControlHost broken designer behavior
        /// </summary>
        public class DesignerToolStripControlHost : ToolStripControlHost {
            /// <summary>
            /// Fixes designer bug by creating a constructor allowing to create ToolStripControlHost
            /// without parameter
            /// </summary>
            public DesignerToolStripControlHost() : base(new UserControl()) { }
            /// <summary>
            /// Initializes a new instance of the System.Windows.Forms.DesignerToolStripControlHost
            /// class that hosts the specified control
            /// </summary>
            /// <param name="c"></param>
            public DesignerToolStripControlHost(Control c) : base(c) { }
            /// <summary>
            /// Initializes a new instance of the System.Windows.Forms.DesignerToolStripControlHost
            /// class that hosts the specified control and that has the specified name
            /// </summary>
            /// <param name="c"></param>
            /// <param name="name"></param>
            public DesignerToolStripControlHost(Control c, string name) : base(c, name) { }
        }
    }
