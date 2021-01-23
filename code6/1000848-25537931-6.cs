    public class WaitingForOperationState : State
    {
        public override State Process(string token)
        {
            CloseCurrentExpression(token);
            return PushTokenToTokenList(token); // let's imagine the same method as above is accessible here
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
