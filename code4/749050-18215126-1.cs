        public Employee(string n)
        {
            _name = n;
            _number = "AA23TK421";
            _date = 4;
            _salary = 800;
        }
    //} remove this end brace
        public override string ToString()
        {
            return _name; // or whatever you want the result to be
        }
    }  // brace moved to here
