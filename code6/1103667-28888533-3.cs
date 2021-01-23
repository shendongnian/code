    StringBuilder b = new StringBuilder();
    for (int i = 0; i < line.Length; i++ ) {
      char c = line[i];
      if (rnd.Next(2) == 0) {
        c = Char.ToUpper(c);
      }
      b.Append(c);
      if (i % 2 == 1) {
        b.Append(rnd.Next(10));
      }
    }
    line = b.ToString();
