    public async void TaskDelayTest()
    {
         while (LoopCheck)
         {
              for (int i = 0; i < 100; i++)
              {
                   textBox1.Text = i.ToString();
                   await Delay(1000);
              }
         }
    }
    
    private async void Delay(int delayInMillisecond)
    {
        for(int i=0; i<delayInMillisecond; i++)
        {
        	await Task.Delay(1)
        	if(!LoopCheck)
        		break;
        }
    }
