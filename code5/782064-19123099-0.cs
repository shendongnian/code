    public interface IASGUID
    {
       Guid GetGuid();
    }
    
    
    public override void LoadDataToControls<T>(T Id) Where T : IASGUID
    {
    
      // then auto type-checked -- no run-time error possible.
    
      Guid guid = Id.GetGuid(); 
    
    }
