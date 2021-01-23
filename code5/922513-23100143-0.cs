    public void Main()
    {
        Target sometarget = new Target();
        IKernel kernel = new StandardKernel(new Bindings());
        //var weapon = kernel.Get<IWeapon>();
        var character = kernel.Get<Character>();
        character.Attack(sometarget);
    }
