     var strBuild = new StringBuilder();
     var input = MiChatBox.Text;
     MiChatBox.Text = "";
     
     foreach (char CharOfTheEmoticon in input)
     {
         strBuild.Append(CharOfTheEmoticon);
     
         if (CharOfTheEmoticon == '*')
         {
     
             BitmapImage MyImageSource = new BitmapImage(new Uri(@"..\..\..\..\Tarea6\Tarea3Frontend\NewImages\Smile.png", UriKind.Relative));
             Image image = new Image();
     
             image.Source = MyImageSource;
             image.Width = 15;
             image.Height = 15;
             image.Visibility = Visibility.Visible;
             InlineUIContainer container = new InlineUIContainer(image);
     
             var originLastrText = new Run(strBuild.ToString());
             MiChatBox.Inlines.Add(originLastrText);
             MiChatBox.Inlines.Add(container);
     
             strBuild.Clear();
         }
     }
     var textRem = new Run(strBuild.ToString());
     MiChatBox.Inlines.Add(textRem);
