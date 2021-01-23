    using (var writer = new StreamWriter("filepath"))
    {
       Console.SetOut(writer);
       do
       {
           Console.Write("Anna korkeus: ");
           maxHeight = Convert.ToInt32(Console.ReadLine());
           if (maxHeight > 0)  break;
           else continue;
      }
      while (true);
      for (int height = 0; height < maxHeight; height++)
      {
           for (int i = 0; i < (maxHeight - height - 1); i++)
           {
               Console.Write(" ");
           }
           for (int i = 1; i <= (height * 2 + 1); i++)
           {
                Console.Write("*");
           }
           Console.WriteLine();
      }
      writer.Flush();
    }
