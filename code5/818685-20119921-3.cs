    List<Winner> unsortedList = new List<Winner>();
    using(StreamReader sr = new StreamReader("highscores.txt"))
    {
        while((line = sr.ReadLine()) != null))
        {
            Winner w = new Winner();
            w.WinnerScore = int.Parse(line); 
            w.WinnerName = sr.ReadLine(); 
            unsortedList.Add(w);
        }
        sr.Close();
    }
