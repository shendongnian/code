        StringBuilder sb = new StringBuilder();
        Random r = new Random();
        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int pieces = 3, pieceSize = 4;
        for (var i = 0; i < pieces; i++)
        {
            if(i != 0)
                sb.Append(" - ");
            for (var j = 0; j < pieceSize; j++)
            {
                sb.Append(Alphabet[r.Next(Alphabet.Length)]);
            }
        }
        Console.WriteLine(sb.ToString());
