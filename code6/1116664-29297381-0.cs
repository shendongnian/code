    public void Method()
    {
        if(something)
        {
            //some code
            if(something2)
            {
                //now I should break from ifs and go to te code outside ifs
            }
            if(!something2)
                return;
        }
        // The code i want to go if the second if is true
    }
