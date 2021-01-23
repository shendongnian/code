    class Info
    {
        public string Foo { get; set; }
    }
    
    class CarInfo : Info {}
    
    class InfoContainer<T>
        where T: Info
    {
        public List<T> info_list { get; set; }
        
        public bool is_known(T inf)
        {
            if (-1 == info_list.FindIndex(i => i.Foo == inf.Foo)) return false;
            return true;
        }
    }
    class CarFleetInfo : InfoContainer<CarInfo>
    {
    }
