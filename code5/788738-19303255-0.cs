    public override int GetHashCode()
    {  
      unchecked
      { 
          if (_hash == 0)
          {
            _hash = 17;
            _hash = _hash * 31 + Prop1.GetHashCode();
            _hash = _hash * 31 + Prop2.GetHashCode();
            foreach(var child in Children)
            {
                _hash = _hash * 31 + child.GetHasCode();
            }
          }
          return _hash;
      }
    }
