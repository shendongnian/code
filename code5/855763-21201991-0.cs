     bool for3 = false;
                        for (; ; )
                        {
                            Norm.ShowBalloonTip(10000);
                            System.Threading.Thread.Sleep(10000);
                            Application.DoEvents();
                            if (loopVariable)
                                for3 = true;
                            if (for3) break;
                            System.Threading.Thread.Sleep(60000);
                            
                        }
    private static bool loopVariable = false;
        
      void Norm_BalloonTipClicked(object sender, EventArgs e)
       {
           loopVariable = true;
       }
