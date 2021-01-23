      [XmlArray("ps")]
      public List<object> Ps
      {
          List<object> _ps;
          if(_ps == null)
          {
              _ps= new List<object>();
          }
          return _ps;
      }
