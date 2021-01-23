     public void dibujarTexto(String text)
        {
          DropShadowTextBlock textblockTop = new DropShadowTextBlock();
          textblockTop.Text = text;
          textblockTop.Foreground = new SolidColorBrush(Colors.White);
          textblockTop.Name = Guid.NewGuid().ToString();
          migrid.Name= Guid.NewGuid().ToString();
          migrid.Children.Add(textblockTop); //this is a grid control
        }
