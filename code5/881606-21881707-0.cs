    string[] lines = File.ReadAllLines("c:\\1.txt");
    string[] user = lines
		              .Skip(i)
		              .ToArray();
    int userIndex = 0;
    for (int x = 0; x < 1143600; x++)
    {
        for (int y = 0; y < 100; y++)
        {
            float lineu = Convert.ToSingle(user[userIndex++]);
            float linei = Convert.ToSingle(ITEM.ReadLine());
            c[x,y] += linei * lineu;
        }
    }
