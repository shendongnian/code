    private static List<MethodDefinition> GetAllInnerMethods(MethodDefinition method)
    {
        var queueMethodDefinition = new Queue<MethodDefinition>();
        var hsMethodDefinition = new HashSet<MethodDefinition>();
        queueMethodDefinition.Enqueue(method);
        while (queueMethodDefinition.Count > 0)
        {
            MethodDefinition methodCurr = queueMethodDefinition.Dequeue();
            if (!hsMethodDefinition.Contains(methodCurr))
            {
                hsMethodDefinition.Add(methodCurr);
                IEnumerable<MethodDefinition> innerMethodsByCaller = GetInnerMethodsByCaller(methodCurr);
                foreach (var currInnerMethod in innerMethodsByCaller)
                {
                    if (!hsMethodDefinition.Contains(currInnerMethod))
                    {
                        queueMethodDefinition.Enqueue(currInnerMethod);
                    }
                }
            }
        }
        return hsMethodDefinition.ToList();
    }
    private static IEnumerable<MethodDefinition> GetInnerMethodsByCaller(MethodDefinition caller)
    {
        return caller.Body.Instructions
            .Where(x => (x.OpCode == OpCodes.Call || x.OpCode == OpCodes.Calli || x.OpCode == OpCodes.Callvirt) && x.Operand is MethodDefinition)
            .Select(x => (MethodDefinition)x.Operand);
    }
