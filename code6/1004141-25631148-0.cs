      DateTime nextUpdateTime = DateTime.UtcNow;
      private void gameTick(object sender, System.Timers.ElapsedEventArgs e)
      {
         if (DateTime.UtcNow > nextUpdateTime)
         {
            nextUpdateTime = DateTime.UtcNow.AddSeconds(3);
            theGame.Update(...);
         }
         ....
