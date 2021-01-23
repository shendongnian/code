    Frame lastFrame;
    Frame thisFrame;
    void Update()
    {
        LeapInput.Update();
        lastFrame = thisFrame;
        thisFrame = LeapInput.Frame;
        
        long difference = thisFrame.Id - lastFrame.Id;
        while(difference > 0){
          Frame f = controller.Frame(difference);
          GestureList gestures = f.Gestures();
          if(gestures.Count > 0){
            foreach(Gesture gesture in gestures){
              Debug.Log(gesture.Type + " found in frame " + f.Id);
            }
          }
          difference--;
        }
        
    }
