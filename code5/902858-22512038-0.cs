    bool buttonPressed = false;
    
    private void onChangeSizeButton_pressed(EventArgs e, object o)
    {
       if (buttonPressed)
       {
          this.Size = new Size(this.Size.Width, DEFAULT HEIGHT HERE);
          buttonPressed = false;
       }
       else
       {
          this.Size = new Size(this.Size.Width, NEW HEIGHT HERE);
          buttonPressed = true;
       }
    }
