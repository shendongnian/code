    void timer_Tick(object sender, EventArgs e)
    {
        // Read a queue, that contains timings
        var nextItem = PeekAtQueue();
        if ((nextItem != null) && (nextItem.WhenToChangeColor <= DateTime.Now))
        {
            var item = TakeFromQueue(); // as opposed to just peeking
            ChangeColor(item);
        }
    } 
                             
