    private void PLAY_Click(object sender, EventArgs e) 
    {
        isPrime=false;
        bwHILO.RunWorkerAsync(segundos);
    }
    private bwHILO_DoWork(object sender, DoWorkEventArgs e)
    {
       bool isPrime = ESPrimo((int) e.Argument);
       e.Result=isPrime;
    }
 
    private bwHILO__RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       bool result = (bool)e.Result;
      if(result)
      {
        label2.ForeColor = Color.Maroon;
      } 
      else
      {
        label2.ForeColor = Color.Black;
       }
    }
