	using System;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	public static class NativeExtensions
	{
		private const int TVM_SELECTITEM = (0x1100 + 11);
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
    	public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
		/// <summary>
        /// Forces the selection of this <see cref="System.Windows.Forms.TreeNode"/> using an unsafe SendMessage call
        /// </summary>
        /// <param name="selectionType">Type of selection to make</param>
        /// <exception cref="System.NullReferenceException">This node is null</exception>
        /// <exception cref="System.ArgumentException">The handle for this node is not created, the node does
        /// not have a parent <see cref="System.Windows.Forms.TreeView"/>, or the handle for the node's parent <see cref="System.Windows.Forms.TreeView"/>
        /// is not created</exception>
        public static void ForceSelection(this TreeNode nodeToSelect, UnmanagedTreeNodeSelectType selectionType)
        {
            if (nodeToSelect == null)
                throw new NullReferenceException();
            if (nodeToSelect.Handle == IntPtr.Zero)
                throw new ArgumentException("Handle for node is not created");
            if (nodeToSelect.TreeView == null)
                throw new ArgumentException("Node does not have a parent TreeView.");
            if (nodeToSelect.TreeView.Handle == IntPtr.Zero)
                throw new ArgumentException("Handle for node's parent TreeView is not created.");
            nodeToSelect.TreeView.SelectedNode = nodeToSelect;
            SendMessage(new HandleRef(nodeToSelect.TreeView, nodeToSelect.TreeView.Handle), TVM_SELECTITEM, (IntPtr)selectionType, nodeToSelect.Handle);
        }
        /// <summary>
        /// Type of selection to make when forcing a <see cref="System.Windows.Forms.TreeNode"/> selection with unmanaged code
        /// </summary>
        public enum UnmanagedTreeNodeSelectType
        {
            //Documentation taken from http://msdn.microsoft.com/en-us/library/31917zyz.aspx
            /// <summary>
            /// Sets the selection to the given item
            /// </summary>
            SetSelection = 0x0009, //TVGN_CARET
            /// <summary>
            /// Redraws the given item in the style used to indicate the target of a drag-and-drop operation
            /// </summary>
            DragAndDropTarget = 0x0008, //TVGN_DROPHILITE
            /// <summary>
            /// Scrolls the tree view vertically so that the given item is the first visible item
            /// </summary>
            FirstVisible = 0x0005, //TVGN_FIRSTVISIBLE
        }
	}
