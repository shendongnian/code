    private void DumpCharacters()
        {
            for (int y = 0; y < yMax; y++)
            {
                string line = string.Empty;
                for (int x = 0; x < xMax; x++)
                {
                    line += characters[x, y];
                }
                Console.SetCursorPosition(0, y);
                Console.Write(line);
            }
            Console.SetCursorPosition(0, 0);
        }
