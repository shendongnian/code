    public interface IEnvironment {
        double Gravity { get; set; }
    }   
    public interface IState {
        string Name { get; }
        bool Is(object target);
    }
    public interface IStateful {
        void SetState(string  name);
        void SetState(string name, Func<object, bool> test);
        void ClearState(string name);
        bool IsInState(string name);
    }
