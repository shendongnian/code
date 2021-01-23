    public void CallIfTypeC(A a)
    {
        if (a is C)
        {
            C c = a as C;
            c.DoAction();
        }
    }
