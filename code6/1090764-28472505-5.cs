    IObservable<MachineClass> _myObservable;
    
    private MachineClass connect()
    {
        MachineClass rpc = new MachineClass();
       _myObservable=Observable
                     .FromEventPattern<MachineClass>(
                                h=> rpc.RxVARxH += h,
                                h=> rpc.RxVARxH -= h)
                     .Throttle(TimeSpan.FromSeconds(1));
       _myObservable.Subscribe(machine=>eventRxVARxH(machine));
        return rpc;
    }
