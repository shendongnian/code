    public async void TaskDelayTest()
    {
         while (LoopCheck)
         {
              for (int i = 0; i < 100; i++)
              {
                   textBox1.Text = i.ToString();
                   await Task.Run(()=>Delay(1000));
              }
         }
    }
    
    private void Delay(int delayInMillisecond)
    {
        double delayInSec = (double) delayInMillisecond / 1000;
        var sw = new Stopwatch();
        sw.Start();
        while(true){
        	double ticks = sw.ElapsedTicks;
    		double seconds = ticks / Stopwatch.Frequency;
    		if(seconds >= delayInSec || !LoopCheck)
    			break;
        }
    }
