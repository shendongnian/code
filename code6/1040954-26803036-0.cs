        [Language("ExpressionEvaluator", "1.0", "Multi-line expression evaluator")]
        public class ExpressionEvaluatorGrammar : Grammar
        {
            public ExpressionEvaluatorGrammar()
            {
                // 1. Terminals
    
                var identifier = new RegexBasedTerminal("identifier", "[a-z\\d_^~]+");
    
    
                // 2. Non-terminals
                var root = new NonTerminal("root");
                var block = new NonTerminal("block");
                var expression = new NonTerminal("expression");
                var expressions = new NonTerminal("expressions");
    
                var prop = new NonTerminal("prop");
                var op = new NonTerminal("op");
    
                // 3. BNF rules
                op.Rule = ToTerm("OR") | "AND";
                prop.Rule = identifier + "=" ;
    
    
                expression.Rule = "{" + (prop | block) + "}" + "|" ;
                expressions.Rule = MakeStarRule(expressions,  expression);
                block.Rule = expressions  + op;
                root.Rule = "{" + block +"}";
    
                Root = root;
                //automatically add NewLine before EOF so that our BNF rules work correctly when there's no final line break in source
                this.LanguageFlags =  LanguageFlags.NewLineBeforeEOF;
            }
        }
    } //namespace
