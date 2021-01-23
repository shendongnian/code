    public override int GetHashCode() 
    {
         return this.stationID.GetHashCode() ^ this.name.GetHashCode();
    }
    public override bool Equals(Object obj) 
    {
         if(Object.ReferenceEquals(this, obj))
         {
              return true;
         }
         BatteryStation other = obj as BatteryStation;
         if(Object.ReferenceEquals(other, null))
         {
             return false;
         }
         return ((this.stationID == other.stationID) && (this.name == other.name));
    }
