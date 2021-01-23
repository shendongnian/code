    class TreeNode
    {
        private enum ParseState
        {
            Operator,
            Expression
        }
        public static TreeNode ParseTree(string treeData)
        {
            Stack<TreeNode> parsed = new Stack<TreeNode>();
            StringBuilder nodeData = new StringBuilder();
            ParseState state = ParseState.Operator;
            for (int charIndex = 0; charIndex < treeData.Length; charIndex++)
            {
                switch (treeData[charIndex])
                {
                    case '{':
                        nodeData.Clear();
                        state = ParseState.Expression;
                        break;
                    case '\t':
                    case ' ':
                    case '\r':
                    case '\n':
                    case '|':
                        // ignore whitespace and |
                        break;
                    case '}':
                        {
                            if (state == ParseState.Expression)
                            {
                                state = ParseState.Operator;
                                parsed.Push(new TreeNodeData(nodeData.ToString()));
                            }
                            else // Operator
                            {
                                TreeNodeOperators op = (TreeNodeOperators)(Enum.Parse(typeof(TreeNodeOperators), nodeData.ToString()));
                                TreeNodeExpression exp = new TreeNodeExpression();
                                exp.Operator = op;
                                exp.Right = parsed.Pop();
                                exp.Left = parsed.Pop();
                                parsed.Push(exp);
                            }
                            nodeData.Clear();
                        }
                        break;
                    default:
                        nodeData.Append(treeData[charIndex]);
                        break;
                }
            }
            return parsed.Pop();
        }
    }
    enum TreeNodeOperators
    {
        AND,
        OR
    }
    class TreeNodeExpression : TreeNode
    {
        public TreeNodeOperators Operator {get; set;}
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
    class TreeNodeData : TreeNode
    {
        public string Data {get; set;}
        public TreeNodeData(string data)
        {
            Data = data;
        }
    }
