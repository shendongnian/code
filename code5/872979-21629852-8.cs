    var method = typeBuilder.DefineMethod(
        "GetKeyImpl",
        MethodAttributes.Private |
        MethodAttributes.Static | 
        MethodAttributes.HideBySig);
    var type = E.Parameter(typeof(Type), "type");
    var knownTypes = E.Parameter(typeof(Type[]), "knownTypes");
    var answer = E.Variable(typeof(int), "answer");
    var i = E.Variable(typeof(int), "i");
    var breakTarget = E.Label("breakTarget");
    var continueTarget = E.Label("continueTarget");
    var returnTarget = E.Label(typeof(int), "returnTarget");
    var forLoop = E.Block(
        new[] { i },
        E.Assign(i, E.Constant(0)),
        E.Loop(
            E.Block(
                E.IfThen(
                    E.GreaterThanOrEqual(i, E.ArrayLength(knownTypes)),
                    E.Break(breakTarget)),
                E.IfThen(
                    E.Equal(E.ArrayIndex(knownTypes, i), type),
                    E.Return(returnTarget, i)),
                E.Label(continueTarget),
                E.PreIncrementAssign(i))),
        E.Label(breakTarget));
    var body = E.Lambda<Func<Type, Type[], int>>(
        E.Block(
            new[] { answer },
            E.Assign(answer, E.Constant(-1)),
            forLoop,
            E.Label(returnTarget, answer)),
        type,
        knownTypes);
    body.CompileToMethod(method);
    return method;
