     /// <summary>
    /// Build up a new Gamefield with the number of buttons, the user has selected
    /// </summary>
    private void DrawGameField()
    {
      var buttons = new Button[_xLength, _yLength];
      for (int yPos = 0; yPos < _yLength; yPos++)
      {
        for (int xPos = 0; xPos < _xLength; xPos++)
        {
          var btn = new Button()
          {
            Tag = new Point(xPos, yPos),
            Location = new Point(xPos * 30, yPos * 30),
            Size = new Size(30, 30)
          };
          btn.MouseClick += Button_MouseClick; //first change here: Use MouseClick!!!
          buttons[xPos, yPos] = btn;
        }
      }
      AddGameButtonsToPanel(buttons);
    }
    /// <summary>
    /// Adds Buttons to the gamepanel
    /// </summary>
    private void AddGameButtonsToPanel(Button[,] buttons)
    {
      _buttons = buttons;
      _gamePanel.SuspendLayout();
      try
      {
        foreach (var btn in buttons)
          _gamePanel.Controls.Add(btn);
      }
      finally
      {
        _gamePanel.ResumeLayout();
      }
    }
    /// <summary>
    /// Checks which mouse-button was clicked and calls the correct method for that button
    /// </summary>
    private void Button_MouseClick(object sender, MouseEventArgs e)
    {
      // If it is the firs time a button is clicked, the stopwatch is started
      if (_firstClick)
        StartStopWatch();
      var btn = sender as Button;
      Point pt = (Point)btn.Tag;
      if (e.Button == MouseButtons.Left)
        Button_LeftClick(btn, pt);
      else
        Button_RightClick(btn, pt);
    }
