    private static void Main(string[] args)
    {
        var ttea = new TokenToExpressionAggregator();
        foreach (var l in new string[] { "a+", "+1", "+c-", "d", "e", "+d", "z+", "a+" }) {
            ttea.Add(l);
        }
        ttea.EndAggregation();
        foreach (var expression in ttea.CurrentState.Expressions) {
            Console.WriteLine(expression);
        }
    }
    public class TokenToExpressionAggregator
    {
        public State CurrentState { get; set; }
        public TokenToExpressionAggregator()
        {
            CurrentState = new InitialState();
        }
        public void Add(string token)
        {
            CurrentState = CurrentState.Process(token);
        }
        public void EndAggregation()
        {
            CurrentState = new FinalState(CurrentState);
        }
    }
    public abstract class State
    {
        public static string[] operators = new string[] { "+", "-", "*", "/" };
        public List<string> Expressions { get; set; }
        public List<string> Tokens { get; set; }
        public abstract State Process(string token);
        protected State PushTokenToTokenList(string token)
        {
            Tokens.Add(token);
            if (operators.Any(op => token.EndsWith(op)))
            {
                return new WaitingForAnyTokenState() { Expressions = Expressions, Tokens = Tokens };
            }
            return new WaitingForOperationState() { Expressions = Expressions, Tokens = Tokens };
        }
        protected void CombineTokensIntoExpression()
        {
            Expressions.Add(string.Join(" ", Tokens.ToArray()));
        }
    }
    public class InitialState : WaitingForAnyTokenState
    {
        public InitialState()
        {
            Expressions = new List<string>();
            Tokens = new List<string>();
        }
    }
    public class WaitingForAnyTokenState : State
    {
        public override State Process(string token)
        {
            return PushTokenToTokenList(token);
        }
    }
    public class WaitingForOperationState : State
    {
        public override State Process(string token)
        {
            CloseCurrentExpression(token);
            return PushTokenToTokenList(token);
        }
        private void CloseCurrentExpression(string token)
        {
            if (!operators.Any(op => token.StartsWith(op)))
            {
                CombineTokensIntoExpression();
                Tokens = new List<string>();
            }
        }
    }
    public class FinalState : State
    {
        public FinalState(State state)
        {
            Expressions = state.Expressions;
            Tokens = state.Tokens;
            CombineTokensIntoExpression();
            Tokens = null;
        }
        public override State Process(string token)
        {
            return this;
        }
    }
