    var var1 = Expression.Variable(typeof(A), "var1");
    var var2 = Expression.Variable(typeof(B), "var2");
    Expression<Action> withBlocks =
        Expression.Lambda<Action>(
            Expression.Block(
                new[] { var1, var2 },
                Expression.Block(
                    Expression.Block(
                        Expression.Assign(
                            var1,
                            Expression.New(typeof(A).GetConstructors().Single())),
                        var1),
                    Expression.Block(
                        Expression.Assign(
                            var2,
                            Expression.New(
                                typeof(B).GetConstructors().Single(), var1)),
                        var2))));
    Expression<Action> withoutBlocks =
        Expression.Lambda<Action>(
            Expression.Block(
                new[] { var1, var2 },
                Expression.Assign(
                    var1, Expression.New(typeof(A).GetConstructors().Single())),
                Expression.Assign(
                    var2,
                    Expression.New(typeof(B).GetConstructors().Single(), var1))));
    var assembly = AssemblyBuilder.DefineDynamicAssembly(
        new AssemblyName("test"), AssemblyBuilderAccess.Save);
    var module = assembly.DefineDynamicModule("test.dll");
    var type = module.DefineType("Type");
    var withBlocksMethod = type.DefineMethod(
        "WithBlocks", MethodAttributes.Public | MethodAttributes.Static,
        typeof(void), Type.EmptyTypes);
    withBlocks.CompileToMethod(withBlocksMethod);
    var withoutBlocksMethod = type.DefineMethod(
        "WithoutBlocks", MethodAttributes.Public | MethodAttributes.Static,
        typeof(void), Type.EmptyTypes);
    withoutBlocks.CompileToMethod(withoutBlocksMethod);
    type.CreateType();
    assembly.Save("test.dll");
