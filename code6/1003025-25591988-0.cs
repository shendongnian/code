    public void animation(){
              timer1.start();
              labelStatus.Visibility=false;
        }
    private void timer1_Tick(object sender, EventArgs e)
        {
            [...]
    
            else if (fromY < moveToY)
            {
                Y = Y + 5;
                lblMove.Location = new Point(fromX, Y);
            }
            else
            {
                timer1.Stop();
    labelStatus.Visibility = true;
            }
        }
