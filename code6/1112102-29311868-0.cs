    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace SampleTextParsing
    {
        class Program
        {
            /// <summary>
            /// String representing the hierarchy to be parsed into objects.
            /// </summary>
            static readonly string fileString = 
            @"Item0
            --Item1
            ----Property1
            ----Property2
            ----Item2
            ------Property1
            ------Property2
            ----Item3
            ----Item4
            ------Property1
            ------Property2
            ----Item5
            --Item6
            --Item7
            ----Property1
            --End
            End";
    
            static void Main(string[] args)
            {
                // Create a collection of nodes out of the string.
                Queue<BaseNode> nodes = Parse();
    
                // Display the results to the user.
                Console.WriteLine("Element string\r\n-------------------------------");
                Console.WriteLine(fileString.Replace(' ', '\r'));
    
                Console.WriteLine("\r\nTotals\r\n-------------------------------");
                DisplayTotals(nodes);
    
                Console.WriteLine("\r\nHierarchy\r\n-------------------------------");
                while (nodes.Count > 0)
                {
                    DisplayRelationships(nodes.Dequeue());
                }
    
                Console.ReadLine();
            }
    
            /// <summary>
            /// Parses the hierarchy string into a collection of objects.
            /// </summary>
            /// <returns>The string node as a BaseNode Object</returns>
            static Queue<BaseNode> Parse()
            {
                BaseNode root = null;       // Keeps track of the top most parent (Eg. In this case, item0 or End
                BaseNode current = null;    // Keeps track of the node to compare against.
                BaseNode previous = null;   // Keeps track of the previously seen node for comparison.
                Queue<BaseNode> queue = new Queue<BaseNode>(); ;    // Contains a queue of nodes to be returned as the result.
    
                // Split the string into it's elements by using the carriage return and line feed.  
                // You can add a white-space character as a third delimiter just in case neither of the other two exist in the string. (eg. Inline)
                string[] elements = fileString.Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
    
                // Iterate through every string element and create a node object out of it, while setting it's parent relationship to the previous node.
                foreach (var element in elements)
                {
                    // Check if a root node has been determined (eg. top most parent).  If not, assign it as the root and set it as the current node.
                    if (root == null)
                    {
                        root = GetAsElementNode(element);
                        current = root;
                    }
                    // The root has already been determined and set as the current node.  So now we check to see what it's relationship is to the 
                    // previous node. (eg. Child to parent)
                    else
                    {
                        // Assign the current node as previous, so that we have something to compare against. (eg. Previous to Current)
                        previous = current;
    
                        // Create a node out of the string element.
                        current = GetAsElementNode(element);
    
                        // We use the depth (eg. integer representing how deep into the hierarchy we are, where 0 is the root, and 2 is the first child
                        // (This is determined by the number of dashes prefixing the element. eg. Item0 -> --Item1)) to determine the relationship. 
                        // First, lets check to see if the previous node is the parent of the current node.
                        if (current.Depth > previous.Depth)
                        {
                            // It is, so assign the previous node as being the parent of the current node.
                            current.Parent = previous;
                        }
                        // The previous node is not the parent, so now lets check to see if the previous node is a sibling of the current node. 
                        // (eg. Do they share the same parent?)
                        else if (current.Depth == previous.Depth)
                        {
                            // They do, so get the previous node's parent, and assign it as the current node's parent as well.
                            current.Parent = previous.Parent;
                        }
                        // The current node is not the parent (eg. lower hierarchy), nor is it the sibling (eg. same hierarchy) of the previous node.  
                        // So it must be higher in the hierarchy. (eg. It's depth is less than the previous node's depth.)
                        else
                        {
                            // So now we must determine what the previous sibling node was and assign it as the current node's parent temporarily
                            BaseNode previousSibling = queue.FirstOrDefault(sibling => sibling.Depth == current.Depth);
                            current.Parent = previousSibling;
    
                            // The only time that the pervious sibling should be null is if the sibling is a root node. (eg. Item0 or End)
                            if (previousSibling == null)
                            {
                                current.Parent = null;
                            }
                            // The previous sibling has a parent, so we will the parent of the current node to match it's sibling.
                            else
                            {
                                current.Parent = previousSibling.Parent;
                            }
                        }
                    }
    
                    // We now add the node to the queue that will be returned as the result.
                    queue.Enqueue(current);
                }
    
                return queue;
            }
    
            /// <summary>
            /// Simply outputs to console, the name of the node and it's relationship to the previous node if any.
            /// </summary>
            /// <param name="node">The node to output the name of.</param>
            private static void DisplayRelationships(BaseNode node)
            {
                string output = string.Empty;
                if (node.Parent == null)
                {
                    output = string.Format("{0} is a root node.", node.Name);
                }
                else
                {
                    output = string.Format("{0} is a child of {1}.", node.Name, node.Parent.Name);
                }
    
                Console.WriteLine(output);
            }
    
            /// <summary>
            /// Displays the total counts of each relationship.  The numbers appear slightly off because the clauses are not 
            /// taking into account that a root node has no parent but can have children.  So Item0 and End are excluded from the count
            /// but included in the root count.  The values are right otherwise.
            /// </summary>
            /// <param name="nodes">A queue of nodes to iterate through.</param>
            private static void DisplayTotals(Queue<BaseNode> nodes)
            {
                var totalRoot = nodes.Where(node => node.Parent == null).Count();
                var totalChildren = nodes.Where(node => node.Parent != null).Count();
                var totalChildless = nodes
                    .Where(node => node.Parent != null)
                    .Join(
                        nodes.Where(
                        node => (node.Parent != null)), 
                            parent => parent.Name, 
                            child => child.Parent.Name, 
                            (parent, child) => new { child })
                            .Count();
    
    
                Console.WriteLine("{0} root nodes.", totalRoot);
                Console.WriteLine("{0} child nodes.", totalChildren);
                Console.WriteLine("{0} nodes without children.", totalChildless);
                Console.WriteLine("{0} parent nodes.", totalChildren - totalChildless);
            }
    
            /// <summary>
            /// Creates a node object from it's string equivalent.
            /// </summary>
            /// <param name="element">The parsed string element from the hierarchy string.</param>
            /// <returns></returns>
            static BaseNode GetAsElementNode(string element)
            {
                // Use some regex to parse the starting portion of the string.  You can also use substring to accomplish the same thing.
                string elementName = Regex.Match(element, "[a-zA-Z0-9]+").Value;
                string link = Regex.Match(element, "-+").Value;
    
                // Check if its a root element, otherwise assume that it must be a parent with children
                return new Node(elementName, link.Length);
            }
        }
    
        /// <summary>
        /// A node object which inherits from BaseNode.
        /// </summary>
        public class Node : BaseNode
        {
            public Node()
            {
            }
    
            /// <summary>
            /// Overloaded constructor which accepts a string element and the depth
            /// </summary>
            /// <param name="elementName">The element as a string</param>
            /// <param name="depth">The depth of the element determined by the number of dashes prefixing the element string.</param>
            public Node(string elementName, int depth)
                : base(elementName, depth)
            {
            }
        }
    
        /// <summary>
        /// A base node which implements the INode interface. 
        /// </summary>
        public abstract class BaseNode : INode
        {
            public string Name { get; set; }        // The name of the node parsed from the string element.
            public int Depth { get; set; }          // The depth in the hierarchy determined by the number of dashes (eg. Item0 -> --Item1)
            public BaseNode Parent { get; set; }    // The parent of this node.
    
            public BaseNode()
            {
            }
    
            /// <summary>
            /// Overloaded constructor which accepts a string element and the depth.
            /// </summary>
            /// <param name="elementName">The element as a string.</param>
            /// <param name="depth">The depth of the element determined by the number of dashes prefixing the element string.</param>
            public BaseNode(string elementName, int depth)
                : this()
            {
                this.Name = elementName;
                this.Depth = depth;
            }
        }
    
        /// <summary>
        /// The interface that is implimented by the BaseNode base class.
        /// (For this scenario, this is a bit overkill but I figured, if I'm going to propose a solution, to do it right!)
        /// </summary>
        public interface INode
        {
            string Name { get; set; }        // The name of the node parsed from the string element.
            int Depth { get; set; }          // The depth in the hierarchy determined by the number of dashes (eg. Item0 -> --Item1)
            BaseNode Parent { get; set; }    // The parent of this node.
        }
    }
