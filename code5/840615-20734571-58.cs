    //Console Application Example #3 ;)
    static void Main()
    {
        // List<Action<int>> is a List that stores objects of Type Action<int>
        // Action<int> is a Delegate that represents methods that
        //  takes an int but does not return (example: void func(int val){/*code*/})
        var myDelegates = new List<Action<int>>();
        // We add delegates to the list
        myDelegates.Add(x => Console.WriteLine(x));
        myDelegates.Add(x => Console.WriteLine(x + 5));
        // And we call them in succesion
        foreach (var item in myDelegates)
        {
            item(74);
        }
    }
