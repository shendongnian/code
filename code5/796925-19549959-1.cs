    // States
    const int Outside = 0;
    const int InDouble = 1;
    const int InSingle = 2;
    // Inputs
    const int Other = 0;
    const int DoubleQuote = 1;
    const int SingleQuote = 2;
    static readonly int[,] stateTransitions =
    {   /*               Other     DoubleQ   SingleQ */
        /* Outside */  { Outside,  InDouble, InSingle },
        /* InDouble */ { InDouble, Outside,  InDouble },
        /* InSingle */ { InSingle, InSingle, Outside }
    };
    // Do we emit the character or ignore it?
    static readonly bool[,] actions =
    {   /*              Other   DoubleQ SingleQ */
        /* Outside */ { false,  false,  false },
        /* InDouble */{ true,   false,  true  },
        /* InSingle */{ false,  false,  false }
    };
    static int Classify(char c)
    {
        switch (c)
        {
            case '\'': return SingleQuote;
            case '\"': return DoubleQuote;
            default: return Other;
        }
    }
    static IEnumerable<char> FSM(IEnumerable<char> inputs)
    {
        int state = Outside;
        foreach (char input in inputs)
        {
            int kind = Classify(input);
            if (actions[state, kind]) 
                yield return input;
            state = stateTransitions[state, kind];
        }
    }
