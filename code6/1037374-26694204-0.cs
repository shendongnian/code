    //Inside your Globals.cs's class
    public static double[][] arrayOfArrays;
    public static double[] Jan;
    ... //All of your months' variables, without assignment of course.
    static Globals( ) {
        Jan = {Properties.Settings.Default.Jan1Costs,
               Properties.Settings.Default.Jan2Costs,
               Properties.Settings.Default.Jan3Costs,
               Properties.Settings.Default.Jan4Costs,
               Properties.Settings.Default.Jan5Cost,
               Properties.Settings.Default.Jan6Cost,
               Properties.Settings.Default.Jan7Cost};
        ... //Assign here the rest months' variables
        arrayOfArrays = {Jan,
                        Feb,
                        Mar,
                        Apr,
                        May,
                        Jun,
                        Jul,
                        Aug,
                        Sep,
                        Oct,
                        Nov,
                        Dec};
    }
