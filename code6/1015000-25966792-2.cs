    using InterfacesLibrary;
    namespace calculateLibrary
    {
        public class inputParser : IinputParser
        {
            public commandTypes parseCommand(string command)
            {
                return ((commandTypes)Enum.Parse(typeof(commandTypes), command));
    
            }
        }
    }
