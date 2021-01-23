    using (TextReader reader = File.OpenText("Numbers.txt"))
    {
       string[] bits;
       string text = reader.ReadLine();
       int i;
       IList<int> x = new List<int>();
       while (text != null)
       {
          i = 0;
          bits = text.Split(' ');
          while (bits[i] != null)
          {
             x.Add(int.Parse(bits[i]));
             i++;
          }
          text = reader.ReadLine();
       }
    }
