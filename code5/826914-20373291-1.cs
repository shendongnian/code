    private void ProcessAdditions()
    {
        foreach(var operand in _additions.GetConsumingEnumerable())
        {
            _container.Lock.EnterWriteLock();
            _container.Operands.Add(operand);
            _container.Lock.ExitWriteLock();
        }
    }
    
    public void Initialize()
    {
        var pump = new Thread(ProcessAdditions)
        {
            Name = "Operand Additions Pump"
        };
        pump.Start();
    }
