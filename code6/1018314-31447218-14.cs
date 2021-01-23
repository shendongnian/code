    SortedList<int, int> l =
        new SortedList<int, int> { { 1, 1 }, { 3, 3 }, { 4, 4 } };
    for (int i = 0; i <= 5; i++)
    {
        Console.WriteLine("{ { 1, 1 }, { 3, 3 }, { 4, 4 } }.Head( " +i+ ",  true): "
            + string.Join(", ", l.Head(i, true)));
        Console.WriteLine("{ { 1, 1 }, { 3, 3 }, { 4, 4 } }.Head( " +i+ ", false): "
            + string.Join(", ", l.Head(i, false)));
    }
    for (int i = 0; i <= 5; i++)
    {
        Console.WriteLine("{ { 1, 1 }, { 3, 3 }, { 4, 4 } }.Tail( " +i+ ",  true): "
            + string.Join(", ", l.Tail(i, true)));
        Console.WriteLine("{ { 1, 1 }, { 3, 3 }, { 4, 4 } }.Tail( " +i+ ", false): "
            + string.Join(", ", l.Tail(i, false)));
    }
