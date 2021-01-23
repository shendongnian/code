    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    
    namespace stackoverflow1 {
        class Program {
            class Node {
                public int Number;
                public int State = 0;
                public List<Node> Connects = new List<Node>();
                public bool Visited = false;
                public Node(int num, int state) {
                    Number = num;
                    State = state;
                    }
                }
            static void Main(string[] args) {
                var nodes = new List<Node>();
                nodes.Add(new Node(0, -1)); // not used
                nodes.Add(new Node(1, 1));
                nodes.Add(new Node(2, 1));
                nodes.Add(new Node(3, 1));
                nodes.Add(new Node(4, 0));
                nodes.Add(new Node(5, 1));
                nodes.Add(new Node(6, 1));
                nodes.Add(new Node(7, 0));
                nodes.Add(new Node(8, 0));
                nodes.Add(new Node(9, 0));
                nodes[1].Connects.Add(nodes[2]);
                nodes[1].Connects.Add(nodes[4]);
                nodes[2].Connects.Add(nodes[1]);
                nodes[2].Connects.Add(nodes[3]); 
                nodes[2].Connects.Add(nodes[5]);
                nodes[3].Connects.Add(nodes[2]); 
                nodes[3].Connects.Add(nodes[6]);
                nodes[4].Connects.Add(nodes[1]);
                nodes[4].Connects.Add(nodes[5]); 
                nodes[4].Connects.Add(nodes[7]);
                nodes[5].Connects.Add(nodes[2]);
                nodes[5].Connects.Add(nodes[4]); 
                nodes[5].Connects.Add(nodes[6]);
                nodes[5].Connects.Add(nodes[8]);
                nodes[6].Connects.Add(nodes[3]);
                nodes[6].Connects.Add(nodes[5]); 
                nodes[6].Connects.Add(nodes[9]);
                nodes[7].Connects.Add(nodes[4]);
                nodes[7].Connects.Add(nodes[8]); 
                nodes[8].Connects.Add(nodes[5]);
                nodes[8].Connects.Add(nodes[7]); 
                nodes[8].Connects.Add(nodes[9]);
                nodes[9].Connects.Add(nodes[6]);
                nodes[9].Connects.Add(nodes[8]); 
                var stk = new Stack<Node>();
                stk.Push(nodes[1]);
                Node grandparentnode = null;
                int count = 0;
                if (nodes[1].State == 1) count++;
                while (stk.Count > 0) {
                    var n = stk.Pop();
                    foreach (var nn in n.Connects) {
                        if (nn.State == 1) {
                            if (nn != grandparentnode) {
                                if (nn.Visited == false) {
                                    nn.Visited = true;
                                    stk.Push(nn);
                                    count++;
                                    }
                                }
                            }
                        }
                    grandparentnode = n;
                    }
                Console.WriteLine("Count = {0}", count);
                Console.ReadKey();
                }
    }
