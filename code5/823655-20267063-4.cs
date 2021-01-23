    private void mainWinForm_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            int count = 0; // NOTE: outside the delegate
            timer.Elapsed += delegate
            {
                count++;
                if (count == 1)
                {
                    label1.Text = "3 (Get ready!)";
                }
                if (count == 2)
                {
                    label1.Text = "2 (To smile! :) )";
                }
                if (count == 3)
                {
                    label1.Text = "1 (Cheeese!)";
                }
                if (count == 4)
                {
                    label1.Text = "Taken!";
                    imgCapture.Image = imgVideo.Image;
                    timer.Stop();
                }
            };
            timer.Start();
        }
    }
