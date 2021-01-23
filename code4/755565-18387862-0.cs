    class InfoContainer<T> where T : Info
    {
      public virtual List<T> info_list {get; set;}
      public bool is_known(T inf)
      {
       if (-1 == info_list.FindIndex( i => i.str == inf.str) return false;
       return true;
      }
    }
    class CarFleetInfo<T> : InfoContainer<T>
    {
      public override List<CarInfo> info_list {get;set;}
      public CarFleetInfo(){
        info_list = new List<CarInfo>();
      }
    }
