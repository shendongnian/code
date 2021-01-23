            public async void AnimationInSequence()
            {    
                await stor_Completed("13", 'L').BeginAsync();
                await stor_Completed("10", 'D').BeginAsync();
                await stor_Completed("9", 'R').BeginAsync();   
            }
    
            public Storyboard stor_Completed(string num, char direction)
            {
                Button butt = (Button)this.FindName("butt" + num);
                Storyboard stor = (Storyboard)this.FindName("stor" + num);
                ThicknessAnimation thic = (ThicknessAnimation)this.FindName("thic" + num);
                thic.From = butt.Margin;
                thic.To = null;
                //thic.By = null;
                TranslateTransform tt = new TranslateTransform();
                tt.X = butt.RenderTransform.Value.OffsetX;
                tt.Y = butt.RenderTransform.Value.OffsetY;
    
                if (direction == 'U')
                {
                    thic.By = new Thickness(0, -80, 0, 0);
                }
                else if (direction == 'D')
                {
                    thic.By = new Thickness(0, 80, 0, 0);
                }
                else if (direction == 'R')
                {
                    thic.By = new Thickness(80, 0, 0, 0);
                }
                else if (direction == 'L')
                {
                    thic.By = new Thickness(-80, 0, 0, 0);
                }
                stor.Children.Add(thic);
                return stor;
            }
    
