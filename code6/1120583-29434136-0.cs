    var label = new Label();
    
    var trackBar = new TrackBar();
    trackBar.Minimum = 0;
    trackBar.Maximum = 10;
    trackBar.ValueChanged += (s, e) => {
        label.Text = trackBar.Value.ToString();
    };
    trackBar.Value = 5;
    trackBar.TickFrequency = 1;
    trackBar.Width = 200;
    
    var fillingRectangleHeight = 0;
    var fullRectangleBounds = new Rectangle(40, 40, 100, 400);
    var fillColor = Color.Blue;
    
    var panel = new FlowLayoutPanel();
    panel.Controls.Add(trackBar);
    panel.Controls.Add(label);
    panel.Paint += (s, e) => {
        
        var bottom = fullRectangleBounds.Bottom;
        var top = bottom - fillingRectangleHeight;
        var fillingRectangleBounds = new Rectangle(
            fullRectangleBounds.X, top, fullRectangleBounds.Width, fillingRectangleHeight);
            
        using (var fillBrush = new SolidBrush(fillColor))
        {
            e.Graphics.FillRectangle(fillBrush, fillingRectangleBounds);
        }
        
    };
    
    var timer = new System.Windows.Forms.Timer();
    timer.Interval = 1000;
    timer.Tick += (s, e) => {
        fillingRectangleHeight = Math.Min(
            fillingRectangleHeight + trackBar.Value, 
            fullRectangleBounds.Height);
        panel.Invalidate();
        
        if (fillingRectangleHeight == fullRectangleBounds.Height)
        {
            // once the rectangle is full, no point in the timer
            // running anymore
            timer.Stop();
        }
    };
    timer.Start();
    
    panel.Dump();
