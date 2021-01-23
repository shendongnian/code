     void annimate()
        {     
            try
            {       
                double angleToAnimateTo = 20;
                double CurrentAngle = 0;
                bool increment = false;
                while (IsAnimating)
                {
                    if (increment)
                        CurrentAngle++;
                    else
                        CurrentAngle--;
                    if (CurrentAngle == angleToAnimateTo )
                        increment = false;
                    if (CurrentAngle == (angleToAnimateTo * -1))
                        increment = true;
                    
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        this.imgBallon.RenderTransform = new RotateTransform(CurrentAngle);
                    }));
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
