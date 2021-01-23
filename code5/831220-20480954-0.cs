    bool flag = false;
    private void mainWinForm_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (!flag)
            {
                    flag = true;
                    \\.....
                    if (count == 20)
                    {
                        \\.......
                        timer.Stop();
                        flag = false;
                    }
             
                timer.Start();
            }
        }
