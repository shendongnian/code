     private void OnSlideDelta(ManipulationDeltaEventArgs e)
        {
            var delta = e.CumulativeManipulation.Translation;
        
            //If Change in X > Change in Y, its considered a horizontal swipe
            var isDeltaHorizontal = Math.Abs(delta.X) > Math.Abs(delta.Y) ? true : false;
        }
