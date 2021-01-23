    private void Character_KeyDown(object sender, KeyEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
          if (e.KeyCode == Keys.A)
          {
              OnUI(() => XSpeed = 1);
          }
          for (; e.KeyCode == Keys.A;)
          {
              Thread.Sleep(50);
              OnUI(() => Character.Left -= XSpeed);
              if (XSpeed == 0)
              {
                  break;
              }
          }});
    }
    private void Character_KeyUp(object sender, KeyEventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            if (e.KeyCode == Keys.Left)
            {
                OnUI(() => XSpeed = 0); 
            }
        }
      }
