     public class XMLDoc
        {
            public XMLDoc()
            {
                AllStates = new List<State>();
                alphabet = new List<char>();
                transitions = new List<Transition>();    
                alphabet.Add('1');
                alphabet.Add('0');    
            }
            public List<State> AllStates{get;set;}// Our set of all States
            public List<Char> alphabet{get;set;}    // Our alphabet set
            public List<Transition> transitions{get;set;} //; Our set of transitions
            public State startState, finalState{get;set;}
        }
