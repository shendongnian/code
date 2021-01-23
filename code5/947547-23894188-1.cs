    using (StreamReader streamReader = new StreamReader("Content/" + MapName + ".txt"))
    {
        int y = 0;
        do
        {
            string line = streamReader.ReadLine();
            string[] numbers = line.Split(',');
            for (int x = 0; x < numbers.Length; x++)
            {
                Blocks[y, x] = new Block();
                if (int.Parse(numbers[x]) == 1)
                    Blocks[y, x].color = Color.Blue;
                else if (int.Parse(numbers[x]) == 2)
                    Blocks[y, x].color = Color.Violet;
                else
                    Blocks[y, x].color = Color.White;
             }
               y++;
            } while (!streamReader.EndOfStream);
        }
