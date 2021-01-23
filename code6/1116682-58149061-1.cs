    public void Method()
    {
        // Some code here
        bool something = true, something2 = true;
        DoSomething();
        void DoSomething()
        {
            if (something)
            {
                //some code
                if (something2)
                {
                    // now I should break from ifs and go to te code outside ifs
                    return;
                }
                return;
            }
        }
        // The code i want to go if the second if is true
        // More code here
    }
