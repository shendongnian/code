    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
            {            
                pBalls.add(e.Location); // you add element at index 0
                pictureBox1.Refresh();
                count++; // count++ mean count = 1;
                
                // now you passing 1 but the list only has zero index right. 
                Point shotHit = pBalls.getPoints(count); 
    
                if (ptrEinstein.Location == shotHit)
                {
                    stopwatch.Stop();
                    MessageBox.Show("It took " + count + " shots and " + stopwatch.Elapsed + " seconds to hit the target");
                }            
            }       
