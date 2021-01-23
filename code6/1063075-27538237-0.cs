    public interface IReadable {
        int SomeProperty {get;}
    }
    
    public interface IInitializable : IReadable {
        int SomeProperty {get;set;}
    }
    
    IReadable _passItOn;
    public void InitializeAndUse(IInitializable initAndUse){
        _passItOn = initAndUse;
        initAndUse.SomeProperty = 42;
    
        UseReadOnly(_passItOn);
    }
