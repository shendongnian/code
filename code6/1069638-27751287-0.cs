    private Task CommandtWatcher()
    {
         return Task.Run(() =>
         {
             // Both PR and D2H are classes from external dll files
             // PR is ProcessMemoryReader class, it reads a message from X window
             if(PR[0].getLastChatMsg().Equals("#eg"))    // If I typed "#eg" then
             {
                 D2HList[0].QuitGame("WindowToBeClosed"); // Close game window
             }
         }       
    }
