    WriteToLog("Hello!"); 
    Action act = delegate() { WriteToLog("How are you?"); }; actionList.Add(act); // Create a new Action out of this method and add it to the action list!
    CreatePause(3000); // Call the method with your specified time
    void CreatePause(int millisecondsToPause)
        {
            Action w = delegate() { Thread.Sleep(millisecondsToPause); };
            for (int i = 0; i < actionList.Count; i++) // Iterate through each method in the action list that requires attention
            {
                Action a_Instance = (Action)actionList[i]; // Add a cast to each iteration
                AsyncCallback cb = delegate(IAsyncResult ar) { Invoke(a_Instance);  w.EndInvoke(ar); };   // Do each method!!!!
                w.BeginInvoke(cb, null);
            }
            actionList.Clear();  // Clear that list!
            return; // Return!
        }
