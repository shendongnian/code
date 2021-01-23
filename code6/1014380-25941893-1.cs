        bool postReveal;       
        private int defaultsize = picture.size;
        private void AnimateCard(PictureBox picture)
        {
            postReveal = false;
            Timer1.Interval(12);
            Timer1.Start();
        }
    
        private void Timer1_Tick(object obj, Eventargs e)
        {
            Size temp = defaultSize;
            if (!postReveal)
            {
                //We are still hiding/shrinking
                for (int w = defaultSize.Width; w != 0; w -= 2)
                {
                    picture.Size = w;
                }
                //This indicates the shrinking process is over
                if (picture.Size <= 0)
                {
                    postReveal = true;
                }
            } else // We are now revealing the other side of the card
            {
                //Change the picture now
                for (int w = temp.Width; w != defaultSize.Width; w += 2)
                {
                    picture.Size = w;
                }
                if (picture.Size = defaultsize)
                {
                    //Animation is Over
                    Timer1.Stop();
                }
            }
        }
