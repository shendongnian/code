        bool postHiding;       
        private int defaultsize = picture.size;
        private void AnimateCard(PictureBox picture)
        {
            postHiding = false;
            Timer1.Interval(12);
            Timer1.Start();
        }
    
        private void Timer1_Tick(object obj, Eventargs e)
        {
            Size temp = defaultSize;
            if (!postHiding)
            {
                picture.Size.Width -=2;
                //This indicates the shrinking process is over
                if (picture.Size <= 0)
                {
                    postHiding = true;
                }
            } else // We are now revealing the other side of the card
            {
                picture.Size.Width += 2;
                
                if (picture.Size >= defaultsize)
                {
                    //Animation is Over
                    Timer1.Stop();
                }
            }
        }
