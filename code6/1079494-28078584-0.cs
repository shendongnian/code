    class C
    {
        A parent;
        X[] x;
    
        public C(A parent)
        {
            this.parent = parent;
        }
    
        insertX() // adds an X element to the x array
        {
            X newX = new X();
            newX.b = parent.findB(searchParam); // returns the matching element from bArray
            // the rest of the code adds newX to array x
        }
    }
