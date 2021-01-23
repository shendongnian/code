    public class People
        {
            string name { get; set; }
    
            public People(string n)
            {
                if (ValidateName(n))
                {
                    this.name = n;
                }
            }
    
            private bool ValidateName(string n)
            {
                char[] nums = "0123456789".ToCharArray();
                if (n.IndexOfAny(nums) >= 0)
                {
                    throw new Exception("Name can't contain numbers.");
                }
                return true;
            }
        }
