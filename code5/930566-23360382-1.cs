        async void timer_Tick(object sender, EventArgs e)
        {
            RunMethod1();
        
            while (count < 15)
            {
                //waiting for 60 seconds 
                await Task.Delay(60000);
                RunMethod2();
            }
        }
