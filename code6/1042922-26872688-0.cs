    public class Sample {
        public Axe[] AxeA;
        public Sample(int nAxe){
            Axe[] AxeA = new Axe[nAxe]; // declaring a new local variable named AxeA which hides the parent scope variable
        }
    }
