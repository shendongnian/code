    if (obj.Time <= 0) {
        rate = 0.00m;
    }
    // At this point, obj.Time already must be >= 0, because the test
    // to see if it was <= 0 returned false.
    else if (obj.Time < 500) {
        rate = 0.75m;
    }
    // And at this point, obj.Time already must be >= 500.
    else if (obj.Time < 1000) { 
        rate = 0.85m;
    }
    else {
        rate = 1.00m;
    }
