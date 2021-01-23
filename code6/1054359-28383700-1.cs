    System.NotSupportedException
        HResult=-2146233067
        Message=The query attempted to call 'OuterApply' over a nested query, but 'OuterApply' did not have the appropriate keys.
        Source=EntityFramework
        StackTrace:
            at System.Data.Entity.Core.Query.PlanCompiler.NestPullup.ApplyOpJoinOp(Op op, Node n)
            at System.Data.Entity.Core.Query.PlanCompiler.NestPullup.VisitApplyOp(ApplyBaseOp op, Node n)
            at System.Data.Entity.Core.Query.InternalTrees.BasicOpVisitorOfT`1.Visit(OuterApplyOp op, Node n)
            ...
