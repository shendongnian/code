    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using StackOverflowExample;
    
    namespace ConsoleApplication1
    {
        [DebuggerVisualizer(typeof(TreeDataVisualizer))]
        [Serializable]
        public class TreeData : ITreeData
        {
            public TreeData(string topData)
            {
                Top = new TreeDataNode(topData);
            }
    
            public ITreeDataNode Top { get; private set; }
        }
    
        [Serializable]
        public class TreeDataNode : ITreeDataNode
        {
            public TreeDataNode(string data)
            {
                Data = data;
                Children = new List<ITreeDataNode>();
            }
    
            public string Data { get; set; }
            public List<ITreeDataNode> Children { get; private set; }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var data = new TreeData("Top Node");
                data.Top.Children.Add(new TreeDataNode("1a"));
    
                var middleChild = new TreeDataNode("1b");
                data.Top.Children.Add(middleChild);
    
                data.Top.Children.Add(new TreeDataNode("1c"));
    
                middleChild.Children.Add(new TreeDataNode("2a"));
                middleChild.Children.Add(new TreeDataNode("2b"));
    
                Debugger.Break();
            }
        }
    }
