    class MySelectorElement
    {
        string ColorId { get; set; }
        string ColorText { get; set; }
        string SizeId { get; set; }
    
        override bool Equals(object other)
        {
            if (other is MySelectorElement)
            {
                return object.Equals(this.ColorId, ((MySelectorElement)other).ColorId);
            }
            else return false;
        }
    
        override int GetHashCode()
        {
            return this.ColorId.getHashCode();
        }
    }
    
    //...
    
    ... Select(new MySelectorElement { ColorId = m.Value.ColorId, ... })
    ...
