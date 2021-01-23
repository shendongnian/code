    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Rextester
    {
        class Program
        {
            public static void Main(string[] args)
            {
                new EpsilonSort(new EpsilonComparer(0.4), 0.1, 0.6, 1, 1.1, 1.6, 2, 2, 2.6, 3, 3.1, 3.6, 4, 4.1, 4.6, 5, 5.1, 5.6, 6, 6.1, 6.6).Sort();
            }
        }
    
        public class EpsilonSort
        {
            private readonly IComparer<double> m_comparer;
            private readonly double[] m_nums;
            public EpsilonSort(IComparer<double> comparer, params double[] nums)
            {
                this.m_comparer = comparer;
                this.m_nums = nums;
            }
    
            public void Sort()
            {
                Node root = new Node();
                root.Datas = new List<double>(this.m_nums);
    
                foreach (double i in (double[])this.m_nums.Clone())
                {
                    this.ProcessNode(i, root);
                }
    
                this.OutputNodes(root);
            }
    
            private void OutputNodes(Node root)
            {
                if (root.Datas == null)
                {
                    foreach (var i in root.Nodes)
                    {
                        this.OutputNodes(i);
                    }
                }
                else
                {
                    if (root.Datas.Count == 1)
                    {
                        Console.WriteLine(root.Datas[0]);
                    }
                    else
                    {
                        Console.Write('(');
                        foreach (var i in root.Datas)
                        {
                            Console.Write(i);
                            Console.Write(' ');
                        }
                        Console.WriteLine(')');
                    }
                }
            }
    
            private void ProcessNode(double value, Node one)
            {
                if (one.Datas == null)
                {
                    foreach (var i in one.Nodes)
                    {
                        this.ProcessNode(value, i);
                    }
                }
                else
                {
                    Node[] childrennodes = new Node[3];
                    foreach (var i in one.Datas)
                    {
                        int direction = this.m_comparer.Compare(i, value);
                        if (direction == 0)
                        {
                            this.AddData(ref childrennodes[1], i);
                        }
                        else
                        {
                            if (direction < 0)
                            {
                                this.AddData(ref childrennodes[0], i);
                            }
                            else
                            {
                                this.AddData(ref childrennodes[2], i);
                            }
                        }
                    }
                    childrennodes = childrennodes.Where(x => x != null).ToArray();
                    if (childrennodes.Length >= 2)
                    {
                        one.Datas = null;
                        one.Nodes = childrennodes;
                    }
                }
            }
    
            private void AddData(ref Node node, double value)
            {
                node = node ?? new Node();
                node.Datas = node.Datas ?? new List<double>();
                node.Datas.Add(value);
            }
    
            private class Node
            {
                public Node[] Nodes;
                public List<double> Datas;
            }
        }
    
        public class EpsilonComparer : IComparer<double>
        {
            private readonly double epsilon;
    
            public EpsilonComparer(double epsilon)
            {
                this.epsilon = epsilon;
            }
    
            public int Compare(double d1, double d2)
            {
                if (Math.Abs(d1 - d2) <= epsilon) return 0;
    
                return d1.CompareTo(d2);
            }
        }
    }
