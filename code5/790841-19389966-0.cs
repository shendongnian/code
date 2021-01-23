    public class MyVisitor : AbstractParseTreeVisitor<object>
    {
        public override object VisitTerminal(ITerminalNode node)
        {
            var text = node.Symbol.Text;
            if (text == "\n")
                text = @"\n";
            Console.WriteLine(" Visit Symbol={0}", text);
            return base.VisitTerminal(node);
        }
    }
