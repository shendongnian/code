    class CharacterResponses
    {
        private bool _isFemale;
    
        new CharacterResponses(bool isFemale)
        {
            _isFemale = isFemale;
        }
    
        public string GetResponse1()
        {
            return _isFemale
                ? "Miss, what's a pretty young thing like you doing out in the dessert."
                : "Sir, what can I do for ya?";
        }
        public string GetResponse2() // For a different conversation.
        // etc...
    }
