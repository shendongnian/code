    public void Test()
    {
        DoWork(new Joystick());
        DoWork(new Mouse());
        // you can do some tests by throwing in a fake device
        // to simulate behaviors that you expect
        DoWork(new FakeDevice());
    }
