            GC.Collect();
            long memCur = GC.GetTotalMemory(false);
            //players = players.OrderByDescending(i => i.Score).ToList();
            players.Sort(ComparePlayersDescending);
            long memNow = GC.GetTotalMemory(false);
            MessageBox.Show(string.Format("Total Memory: {0} {1}, diff {2}", memCur, memNow, memNow - memCur));
