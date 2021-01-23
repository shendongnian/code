    class Element
    {
        string ColorId { get; set; }
        string ColorText { get; set; }
        string SizeId { get; set; }
    
        override bool Equals(object other)
        {
            ...
        }
    
        override int hashCode()
        {
            ...
        }
    }
    
    //...
    
    ... Select(new Element { ColorId = m.Value.ColorId, ... })
    ...
