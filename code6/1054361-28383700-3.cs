    System.NotSupportedException
        HResult=-2146233067
        Message=The nested query does not have the appropriate keys.
        Source=EntityFramework
        StackTrace:
            at System.Data.Entity.Core.Query.PlanCompiler.NestPullup.ConvertToSingleStreamNest(Node nestNode, Dictionary`2 varRefReplacementMap, VarList flattenedOutputVarList, SimpleColumnMap[]& parentKeyColumnMaps)
            at System.Data.Entity.Core.Query.PlanCompiler.NestPullup.Visit(PhysicalProjectOp op, Node n)
            at System.Data.Entity.Core.Query.InternalTrees.PhysicalProjectOp.Accept[TResultType](BasicOpVisitorOfT`1 v, Node n)
            ...
