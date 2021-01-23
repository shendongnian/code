    static MonthOrder getLatestMonth(PersonTimeSheet x)
    {
        x.Dec != 0 ? return MonthOrder.DEC;
        x.Nov != 0 ? return MonthOrder.NOV;
        x.Oct != 0 ? return MonthOrder.OCT;
        // Hopefully you get the picture.
    }
