    int index = j;
    GameHistoryPicBox1[index].BeginInvoke(new MethodInvoker(() =>
        {
            if ((index + index / 6) % 2 == 0)
                GameHistoryPicBox1[index].Image = Properties.Resources.al1;  // Line2
            else
                GameHistoryPicBox1[index].Image = Properties.Resources.al2;  // Line4
        }));
