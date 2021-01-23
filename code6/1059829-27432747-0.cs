    public static void Main() 
    {
      …
      // initialize PID controllers
      PitchAxis = new EulerPID(0.0001, 0.001, 0.001);
      RollAxis = new EulerPID(0.0001, 0.001, 0.001);
      …
    }
