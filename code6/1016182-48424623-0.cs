    void DoSomething()
    {
        Console.WriteLine("You pressed UNDO");
    }
    
    Hook.AppEvents().OnCombination(new Dictionary<Combination, Action>
    {
        {Combination.FromString("Control+Z"), DoSomething},
        {Combination.FromString("Shift+Alt+Enter"), () => { Console.WriteLine("You Pressed FULL SCREEN"); }}
    });
