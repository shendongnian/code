    interface ICar
    {
        IEnumerable<IWheel> Wheels { get; set; }
    }
    
    interface IWheel
    {
        IEnumerable<IBolt> Bolts { get; set; }
    }
    
    interface IBolt
    {
    }
