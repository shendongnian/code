            public async void asynch_stor_Completed()
            {    
                Storyboard stor1, stor2, stor3;
                stor_Completed("13", 'L', out stor1);
                await stor1.BeginAsync();
                stor_Completed("10", 'D', out stor2);
                await stor2.BeginAsync();
                stor_Completed("9", 'R', out stor3);
                await stor3.BeginAsync();   
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
    
