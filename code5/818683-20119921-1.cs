    List<Winner> unsortedList = new List<Winner>();
    using(StreamReader sr = new StreamReader("highscores.txt"))
    {
        for (int u = 0; u < nWinners; u++)
        {
            Winner w = new Winner();
            w.WinnerScore = int.Parse(sr.ReadLine()); 
            w.WinnerName = sr.ReadLine(); 
            unsortedList.Add(w);
        }
        sr.Close();
    }
