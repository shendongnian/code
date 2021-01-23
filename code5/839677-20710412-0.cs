    object w = 44;
    object k1 = (w is double ? (object)((Convert.ToSingle(w))) : (object)((unchecked((uint)Convert.ToInt64(w)))));
    if (w is double)
    {
        w = 22;
    }
    Console.WriteLine("{0}, {1}", w.GetType(), k1.GetType());
    Console.ReadLine();
