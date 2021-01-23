    Cat[] cats = new Cat[10];
    for (int i = 0; i < 10; i++)
    {
      cats[i] = new Cat(); //<------This line is new
      cats[i].Name = "Cat " + sequence.NextValue();
    }
