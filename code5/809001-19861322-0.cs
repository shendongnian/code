    IncreaseButton.Tag = 1;
    DecreaseButton.Tag = -1;
    
    partial void ButtonClick(NSObject sender)
    {
      clickCount = clickCount + ((UIButton)sender).Tag;
      this.CountLabel.Text = clickCount.ToString();
    }
