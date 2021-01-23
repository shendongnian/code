        Context ctx = new Context();
    
        IntExpr t1 = ctx.MkIntConst("t1");
        IntExpr t2 = ctx.MkIntConst("t2");
        IntNum c12 = ctx.MkInt(12);
        IntNum c15 = ctx.MkInt(15);
        IntNum c16 = ctx.MkInt(16);
        IntNum c18 = ctx.MkInt(18);
        IntNum c30 = ctx.MkInt(30);
        Solver solver = ctx.MkSolver();
        BoolExpr constraintInterval12_15 = 
            ctx.MkAnd(ctx.MkLe(c12, t1), ctx.MkLe(t1, c15));
        BoolExpr constraintInterval16_18 = 
            ctx.MkAnd(ctx.MkLe(c16, t2), ctx.MkLe(t2, c18));
        BoolExpr constraintLe20 = 
            ctx.MkLt(ctx.MkAdd(t1, t2), c30);
        solver.Assert(constraintLe20);
        solver.Assert(ctx.MkOr(constraintInterval12_15, constraintInterval16_18));
        if (solver.Check() == Status.SATISFIABLE)
        {
            Model m = solver.Model;
            Console.WriteLine("t1 = " + m.Evaluate(t1));
            Console.WriteLine("t2 = " + m.Evaluate(t2));
        }
