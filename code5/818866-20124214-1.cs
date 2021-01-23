    public class Cashout : Gambler
    {
        public Cashout()
            : base("",0, 0, 1, "", "") //something like this
        {
        }
        public Boolean CheckBalance()
        {
            int tokens = base.Tokens;
            return true;
        }
    }
