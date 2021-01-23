    Color bestMatch;
    int bestSqrDist = Int32.MaxValue;
    foreach (Color consoleColor in consoleColors) {
        int sqrDist = Sqr(theColor.R - consoleColor.R) +
                      Sqr(theColor.G - consoleColor.G) +
                      Sqr(theColor.B - consoleColor.B);
        if (sqrDist < bestSqrDist) {
            bestMatch = consoleColor;
            bestSqrDist = sqrDist;
        }
    }
