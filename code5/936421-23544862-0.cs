    interface ICardValidator
    {
        bool IsCardValid(string cardNumber);
    }
    class LuhnCardValidator : ICardValidator
    {
        private static readonly Regex _cardRegex = new Regex(...);
        bool IsCardValid(string cardNumber)
        {
            return Regex.IsMatch(cardNumber);
        }
    }
