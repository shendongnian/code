    GameHistoryPicBox1[j].BeginInvoke(new Action<int>((x) =>
    {
        if ((x + x / 6) % 2 == 0)
            GameHistoryPicBox1[x].Image = Properties.Resources.al1;
        else
            GameHistoryPicBox1[x].Image = Properties.Resources.al2;
    }), j);
