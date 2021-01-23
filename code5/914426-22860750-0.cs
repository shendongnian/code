    public Driver : IDriver
    {
       public bool Read(ISettings settings, uint[] signal1, uint[] signal2)
       {
          if (settings.PreventSomeThing)
          {
             .....
          }
    
       }
    }
    
    public NullSetting : ISetting
    {
       public bool PreventSomething = false;   
       ....
    }
