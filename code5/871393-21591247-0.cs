    void StartTimer()
    {
        EventHandler tickHandler = null;
        var destination = 5, currentFloor = 0;
        tickHandler = (sender, args) => 
        {
            if (currentFloor == destination)
            {
                lift1Up.Enabled = false;
                lift1Up.Tick -= tickHandler;
                MessageBox.Show("Arrived!");
            }
            else
                currentFloor++;
        }
    
        // start the timer
        lift1Up.Tick += tickHandler;
        lift1Up.Enabled = true;
    }
