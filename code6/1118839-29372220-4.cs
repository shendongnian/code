    // State of specific counter
    private class Counter
    {
        public Timer timer;
        public DateTime startTime;
        public Button button;
        public Label text;
        public Label textLeft;
    }
    // List of counters
    private List<Counter> counters;
    private void Form1_Load(object sender, EventArgs e)
    {
        // Initialize counters
        counters = new List<Counter>();
        counters.Add(new Counter { timer = timer1, button = Button01, text = Button01text, textLeft = Button01textleft });
        counters.Add(new Counter { timer = timer2, button = Button02, text = Button02text, textLeft = Button02textleft });
        counters.Add(new Counter { timer = timer3, button = Button03, text = Button03text, textLeft = Button03textleft });
        counters.Add(new Counter { timer = timer4, button = Button04, text = Button04text, textLeft = Button04textleft });
        counters.Add(new Counter { timer = timer5, button = Button05, text = Button05text, textLeft = Button05textleft });
        // Add more if you need
        // Attach handlers
        foreach (var counter in counters)
        {
            counter.timer.Tick += timerTick;
            counter.button.Click += buttonClick;
        }
    }
    private void timerTick(Object sender, EventArgs args)
    {
        // Prepare context
        var timer = (Timer) sender;
        var counter = counters.Find(c => c.timer == timer);
        var startTime = counter.startTime;
        var button = counter.button;
        var text = counter.text;
        var textLeft = counter.textLeft;
        // Update time
        var time = TimeSpan.FromMinutes(1) - (DateTime.Now - startTime);
        text.Text = time.ToString("hh\\:mm\\:ss");
        textLeft.Text = time.ToString("hh\\:mm\\:ss");
        if (time.TotalSeconds < 1)
        {
            button.BackColor = Color.FromName("Red");
            textLeft.BackColor = Color.FromName("Red");
            timer.Stop();
        }
        else if (time.TotalSeconds < 31)
        {
            button.BackColor = Color.FromName("Orange");
            textLeft.BackColor = Color.FromName("Orange");
        }
    }
    public void buttonClick(object sender, EventArgs e)
    {
        // Prepare context
        var button = (Button)sender;
        var counter = counters.Find(c => c.button == button);
        var timer = counter.timer;
        var textLeft = counter.textLeft;
        // Start counter
        counter.startTime = DateTime.Now;
        button.BackColor = Color.FromName("Green");
        textLeft.BackColor = Color.FromName("Green");
        timer.Enabled = true;
    }
