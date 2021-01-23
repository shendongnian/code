    Console.WriteLine("Seedwaarde (optioneel)");
    int s = Convert.ToInt16(Console.ReadLine());
    Random rand;
    if (s != 0)
    {
       rand = new Random(s);
    }
    else
    {
        rand = new Random();
    }
    for(int i = 0;i < 20; i++){
        rand.next(1, 13);
    }
