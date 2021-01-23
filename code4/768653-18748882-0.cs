    if (obj.Time <= 0) {
        rate = 0.00m;
    }
    else if (obj.Time < 500) {
        rate = 0.75m;
    }
    else if (obj.Time < 1000) { 
        rate = 0.85m;
    }
    else {
        rate = 1.00m;
    }
