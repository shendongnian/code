      class Foo
      {
          public delegate void Setter(float value);
          public float Mass { get; set; }
      
          public Foo()
          {
              Setter massSetter = x => Mass = x;
              // massSetter would be stored somewhere and used later
          }
      }
