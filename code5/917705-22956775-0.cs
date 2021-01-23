    public static bool IsInArea(int testx, int testy, int x1, int y1, int x2, int y2)
    {
        if (testx > x1 && testx < x2 && testy > y1 && testy < y2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
