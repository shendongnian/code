    public class MotherClass : Mother
    {
        // ...
    }
    public class DaughterClass : Daughter
    {
        // ...
    }
    void breakThings()
    {
        new YouJustLostTheGame<Daughter>().Crowd(new MotherClass());
    }
