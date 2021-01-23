    var seat = from b in db.Seats
                    select b;
        
    if (IsNumeric(searchString))
    {             
        seat = seat.Where(b => b.Seat.Contains(searchString));
    }
    
    public bool IsNumeric(string input) {
        int test;
        return int.TryParse(input, out test);
    }
