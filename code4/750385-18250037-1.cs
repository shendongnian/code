     public int Foo { get; set; } // public
     public int Foo { get; private set; } // private
     public int Foo 
     {
        get { return _foo; } // no setter
     }
     public void Poop(); // this member also not part of interface
