        async void timer_Tick(object sender, EventArgs e)
        {
            RunMethod1();
            //waiting for 60 seconds 
            await Task.Delay(60000);
            while (count < 15)
            {
                RunMethod2();
            }
        }
