    for(int i=1; i<= ButtonNos; i++)
    {
     Button NewButton =new Button();
     NewButton.ID = "Newbutton"+i;
     NewButton.Width = 540;
     NewButton.Height = 60;
     NewButton.Text = "Button "+ 1;
     this.Controls.Add(NewButton);
    }
