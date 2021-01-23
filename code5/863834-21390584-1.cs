    class Sprachpaket_ENG_Template01
    {
        MainWindow MW;
        public Sprachpaket_ENG_Template01(MainWindow mw)
        {
            MW = mw;
        }
    }
    class MainWindow()
    {
        public MainWindow()
        {
            Sprachpaket_ENG_Template01 ENG_01 = new Sprachpaket_ENG_Template01(this);
        }
    }
