    public class Specific : Generic<N>
    {
        public override string foo(N n)
        {
            return "I want this specific foo for N (child of M)";
        }
    }
