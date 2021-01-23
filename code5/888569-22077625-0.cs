    bool moveup = false;
    void KeyPressed(object sender, KeyEventArgs e)
    {
       // check for keys that trigger starting of movement
       if (e.KeyCode == Keys.W) moveup = true;
    }
    void KeyReleased(object sender, EventEventArgs e)
    {
       // check for keys that trigger stopping of movement
       if (e.KeyCode == Keys.W) moveup = false;
    }
    void TimerTick(obect sender, EventArgs e)
    {
       if (moveup)
       {
          // move your object
       }
    }
