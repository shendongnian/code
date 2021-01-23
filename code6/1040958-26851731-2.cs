            internal class Node
            {
                public string Terminal { get; set; }
                public List<Node> Operands { get; set; }
            }
    
            internal static readonly Regex TokensPattern = new Regex(@"(?<ws>\s+)|{\s*(?<value>[^\s}]+)\s*}|(?<token>OR|AND|.)", RegexOptions.Compiled);
    
            static Node parseData(string str)
            {
                // init stack
                var stack = new Stack<Node>();
                stack.Push(new Node() { Operands = new List<Node>() });
                // define parser
                var parser = new Dictionary<string, Action<string>>();
                parser.Add("{", _ => stack.Push(new Node() { Operands = new List<Node>() }));
                parser.Add("}", _ => { var top = stack.Pop(); stack.Peek().Operands.Add(top); });
                parser.Add("|", _ => { });
                parser.Add("AND", _ => stack.Peek().Terminal = "AND");
                parser.Add("OR", _ => stack.Peek().Terminal = "OR");
                parser.Add("", value => stack.Peek().Operands.Add(new Node { Terminal = value }));
                // execute parser
                TokensPattern.Matches(str).Cast<Match>()
                    .Where(m => string.IsNullOrEmpty(m.Groups["ws"].Value))
                    .Count(m => { parser[m.Groups["token"].Value](m.Groups["value"].Value); return false; });
                // return top of the tree
                return stack.Peek().Operands[0];
            }
    
            static void Main(string[] args)
            {
                const string str = @"{
        {
            table1~col_b^table1~colc^= 
        }|
        {
            {
                table1~col_b^table2~col_b^=
            }|{
                table2~col_a^table3~cola^=
            }|{cccc}|AND
        }|OR
    }";            
                // print tree function
                Action<int, Node> dump = null;
                dump = new Action<int, Node>((level, node) =>
                {
                    Console.WriteLine("{0}{1}", new string(' ', level * 2), node.Terminal);
                    if (node.Operands != null)
                        node.Operands.ForEach(el => dump(level + 1, el));
                });
                dump(0, parseData(str));
            }
