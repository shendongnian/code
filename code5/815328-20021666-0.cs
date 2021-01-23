    using System.Diagnostics;
    using Microsoft.VisualStudio.DebuggerVisualizers;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace StackOverflowExample
    {
        public interface ITreeData
        {
            ITreeDataNode Top { get; }
        }
    
        public interface ITreeDataNode
        {
            string Data { get; set; }
            List<ITreeDataNode> Children { get; }
        }
    
        /// <summary>
        /// A Visualizer for TreeData.  
        /// </summary>
        public class TreeDataVisualizer : DialogDebuggerVisualizer
        {
            protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
            {
                if (windowService == null)
                    throw new ArgumentNullException("windowService");
                if (objectProvider == null)
                    throw new ArgumentNullException("objectProvider");
    
                var treeData = (ITreeData)objectProvider.GetObject();
                
                using (var treeView = new TreeView())
                {
                    treeView.AutoSize = true;
                    treeView.Dock = DockStyle.Fill;
    
                    var topNode = treeView.Nodes.Add(treeData.Top.Data);
    
                    //Recursively populate all of the child nodes.
                    PopulateNodes(topNode, treeData.Top);
    
                    windowService.ShowDialog(treeView);
                }
            }
    
            private static void PopulateNodes(TreeNode node, ITreeDataNode treeDataNode)
            {
                foreach (var childNode in treeDataNode.Children)
                {
                    var newNode = node.Nodes.Add(childNode.Data);
                    PopulateNodes(newNode, childNode);
                }
            }
        }
    }
