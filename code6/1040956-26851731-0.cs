            internal class Node
            {
                public string Terminal { get; set; }
                public List<Node> Operands { get; set; }
            }
    
            static void Main(string[] args)
            {
                var str = @"{
        {
            table1~col_b^table1~colc^= 
        }|
        {
            {
                table1~col_b^table2~col_b^=
            }|{
                table2~col_a^table3~cola^=
            }|{ cccc }|AND
        }|OR
    }";
                var stack = new Stack<Node>();
                stack.Push(new Node() { Operands = new List<Node>() });
                // tokenize
                new Regex(@"(?<ws>\s+)|{\s*(?<value>\S+)\s*}|(?<token>OR|AND|.)", RegexOptions.Singleline)
                    .Matches(str).Cast<Match>()
                    .Where(m => string.IsNullOrEmpty(m.Groups["ws"].Value))
                    .Select(m => new { Value = m.Groups["value"].Value, Token = m.Groups["token"].Value })
                    .ToList().ForEach(token =>
                    {
                        // parse
                        if (token.Token == "{")
                            stack.Push(new Node() { Operands = new List<Node>() });
                        else if (token.Token == "}")
                        {
                            var top = stack.Pop();
                            stack.Peek().Operands.Add(top);
                        }
                        else if (!string.IsNullOrEmpty(token.Value))
                            stack.Peek().Operands.Add(new Node { Terminal = token.Value });
                        else if (token.Token != "|")
                            stack.Peek().Terminal = token.Token;
                    });
                // print tree
                Action<int, Node> dump = null;
                dump = new Action<int, Node>((level, node) =>
                {
                    Console.WriteLine("{0}{1}", new string(' ', level * 2), node.Terminal);
                    if (node.Operands != null)
                        node.Operands.ForEach(el => dump(level + 1, el));
                });
                dump(0, stack.Peek().Operands[0]);
            }
