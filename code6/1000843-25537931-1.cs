    public class WaitingForAnyTokenState : State
    {
        public override State Process(string token)
        {
            return PushTokenToTokenList(token);
        }
        protected State PushTokenToTokenList(string token)
        {
            Tokens.Add(token);
            if (operators.Any(op => token.EndsWith(op)))
            {
                return new WaitingForAnyTokenState() { Expressions = Expressions, Tokens = Tokens };
            }
            return new WaitingForOperationState() { Expressions = Expressions, Tokens = Tokens };
        }
    }
