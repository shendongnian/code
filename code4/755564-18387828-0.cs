    class Info
        {
          public string str;
        };
    
        class CarInfo : Info {}
    
        class InfoContainer
        {
            public virtual List<Info> info_list {get; set;}
            public bool is_known(Info inf)
            {
              if (!info_list.Exists(p => p.str == inf.str)) return false;
              return true;
             }
        }
    
        class CarFleetInfo : InfoContainer
        {
             public override List<Info> info_list { get; set; }
    
             CarFleetInfo()
             {
                info_list = new List<Info>();
             }
        }
