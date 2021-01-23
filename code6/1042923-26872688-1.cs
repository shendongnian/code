    public class Sample {
        public Axe[] AxeA;
        public Sample(int nAxe){
            AxeA = new Axe[nAxe]; // assigning to parent scope instead of declaring new variable
        }
    }
