    public int Speed
    {
      get
      {
         return CurrentSpeed + CarAcceleration;
      {
    }
    
    public int CarAcceleration{
        get{ 
            if(Speed >= MaxSpeed){
                return MaxSpeed
            }
            return Speed;
        set;
        }
