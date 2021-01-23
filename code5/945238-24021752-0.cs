    var ilgen = Expression.Parameter(typeof(ILGenerator));
    var code = Expression.Parameter(typeof(OpCode));
    var method = Expression.Parameter(typeof(MethodBase));
    var opttypes = Expression.Parameter(typeof(Type[]));
    var stackchange = Expression.Variable(typeof(int));
    var tok = Expression.Variable(typeof(int));
    var paramTypes= Expression.Variable(typeof(Type[]));
    var expr = Expression.Lambda<Action<ILGenerator, OpCode, MethodBase, Type[]>>(Expression.Block(
    new[]{stackchange,tok,paramTypes},
    Expression.Assign(stackchange, Expression.Constant(0)),
    Expression.Assign(tok,
    	Expression.Call(ilgen,
    		typeof(ILGenerator)
    			.GetMethod("GetMethodToken", BindingFlags.NonPublic | BindingFlags.Instance),
    		method,
    		opttypes,
    		Expression.Constant(false)
    	)
    ),
    Expression.Call(ilgen, typeof(ILGenerator).GetMethod("EnsureCapacity", BindingFlags.Instance | BindingFlags.NonPublic), Expression.Constant(7)),
    Expression.Call(ilgen, typeof(ILGenerator).GetMethod("InternalEmit",BindingFlags.Instance|BindingFlags.NonPublic), code),
    Expression.IfThen(
    	Expression.AndAlso(
    		Expression.Not(
    			Expression.Property(method, "IsConstructor")
    		),
    		Expression.Equal(
    			Expression.Property(
    				Expression.Convert(method, typeof(MethodInfo)),
    				"ReturnType"
    			),
    			Expression.Constant(typeof(void))
    		)
    	),
    	Expression.PostIncrementAssign(stackchange)
    ),
    Expression.Assign(paramTypes, Expression.Call(method,
    	typeof(MethodInfo)
    		.GetMethod("GetParameterTypes", BindingFlags.NonPublic | BindingFlags.Instance)
    	)
    ),
    Expression.IfThen(
    	Expression.AndAlso(
    		Expression.AndAlso(
    			Expression.TypeIs(method, Type.GetType("System.Reflection.Emit.SymbolMethod")),
    			Expression.Property(method, "IsStatic")
    		),
    		Expression.Equal(
    			code,
    			Expression.Constant(OpCodes.Newobj, typeof(OpCode))
    		)
    	),
    	Expression.PostDecrementAssign(stackchange)
    ),
    Expression.IfThen(Expression.NotEqual(opttypes, Expression.Constant(null)),
    	Expression.SubtractAssign(stackchange, Expression.ArrayLength(opttypes))
    ),
    Expression.Call(ilgen, typeof(ILGenerator).GetMethod("UpdateStackSize", BindingFlags.NonPublic | BindingFlags.Instance), code, stackchange),
    Expression.Call(ilgen, typeof(ILGenerator).GetMethod("RecordTokenFixup", BindingFlags.NonPublic | BindingFlags.Instance)),
    Expression.Call(ilgen, typeof(ILGenerator).GetMethod("PutInteger4", BindingFlags.NonPublic | BindingFlags.Instance),tok)
    ),
    ilgen, code, method, opttypes);
    var func = expr.Compile();
