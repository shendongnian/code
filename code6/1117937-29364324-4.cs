            public async void AnimationInSequence()
            {    
                Storyboard stor;
                stor_Completed("13", 'L', out stor);
                await stor.BeginAsync();
                stor_Completed("10", 'D', out stor);
                await stor.BeginAsync();
                stor_Completed("9", 'R', out stor);
                await stor.BeginAsync();   
            }
    
            public void stor_Completed(string num, char direction, out Storyboard stor)
            {
                Button butt = (Button)this.FindName("butt" + num);
                stor = (Storyboard)this.FindName("stor" + num);
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
                stor.Begin();
            }
    
