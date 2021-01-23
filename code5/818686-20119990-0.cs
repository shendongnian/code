            var unsortedList = new List<Winner>();
			var nWinners = 100;
			using (StreamReader sr = new StreamReader("highscores.txt"))
			{
				for (int i = 0; i < nWinners; i++)
				{
					var winer = new Winner();
					winer.WinnerScore = int.Parse(sr.ReadLine());
					winer.WinnerName = sr.ReadLine();
					unsortedList.Add(winer);
				}
				sr.Close();
			}
