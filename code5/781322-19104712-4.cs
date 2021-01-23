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
                var dict = new Dictionary<int, Node>();
                foreach (var n in nodes) {
                    if (n.State == 1) {
                        dict.Add(n.Number, n);
                        break;
                        }
                    }
                
                int count = dict.Count;
                while (dict.Count > 0) {
                    foreach (var k in dict.Keys.ToArray()) { // retains node order
                        var n = dict[k]; // get the first node in number order
                        dict.Remove(k);
                        foreach (var node in n.Connects) { // look over it's connections/children
                            if ((node.State == 1) 
                            &&  (node.Number > n.Number))  {
                                if (dict.ContainsKey(node.Number) == false) {
                                    // only add if this is has a greater number than the one
                                    // being considered because lower values have already been
                                    // processed
                                    dict.Add(node.Number, node);
                                    count++;
                                    }
                                }
                            }
                        }
                    }
                Console.WriteLine("Count = {0}", count);
                Console.ReadKey();
                }
            }
    }
