    int i = 2;
    if (i < 10) {
        sum += i; // sum = 2
    }
    i += 2; // i = 4
    if (i < 10) {
        sum += i; // sum = 6
    }
    i += 2; // i = 6
    if (i < 10) {
        sum += i; // sum = 12
    }
    i += 2; // i = 8
    if (i < 10) {
        sum += i; // sum = 20
    }
    i += 2; // i = 10
    if (i < 10) {
        // nothing, since 10 <= 10, but *not* 10 < 10
    }
