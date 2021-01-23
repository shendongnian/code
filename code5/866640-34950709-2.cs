        Task t1 = Task.Factory.StartNew(
            () =>
            {
                DoSomething();
            })
            .ContinueWith(
                (t2) =>
                {
                    DoSomethingWhenComplete();
                },
                TaskContinuationOptions.OnlyOnRanToCompletion)
            .ContinueWith(
                (t3) =>
                {
                    DoSomethingOnError();
                },
                TaskContinuationOptions.OnlyOnFaulted);
    My reasoning behind the indentation I used is that a “child”/“part” of an expression should be indented deeper than the line where its “parent”/“container” begins. In the prior lines, the method’s arguments are part of a method call. So if the method call itself is at one level of indentation, the arguments should be indented one level further:
        MethodCall(
            arg1,
            arg2);
    Likewise, both sides of a binary operator such as scope resolution/member access (`.`) are children of the expression and we can, in a way, think of them all being at the same level. For example, there may be `a.b.c` or `a + b + c`, and I would consider each element to be a child of the overall expression. Thus, since each `.ContinueWith()` is part of the overall statement started on the first line, they should also each be indented just like in the following multiline arithmetic expression:
        var x = 1
            + 2
            + SomethingComplicated();
