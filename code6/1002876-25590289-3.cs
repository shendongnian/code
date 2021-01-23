    var enumerator = generator.Generate().GetEnumerator();
    while (enumerator.MoveNext())
    {
        var instruction = enumerator.Current;
        // do something with instruction
        if (steps > 10)  //some dummy reason to stop ordinary iteration
            break;
    }
    // Now process generator's results manually
    if (!enumerator.MoveNext())
        throw new InstructionMissingException();   // no more instructions left
    var followingInstruction = enumerator.Current;
    // ...
    if (!enumerator.MoveNext())
        throw new InstructionMissingException();   // no more instructions left
    var theLastInstruction = enumerator.Current;
    // ...
    if (enumerator.MoveNext())
        throw new TooMuchInstructionsException(); // unexpected instruction
