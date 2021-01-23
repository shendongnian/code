    public enum AppState { StateOne, StateTwo, StateThree }
    
    public class MyApplication
    {
        public AppState CurrentState { get; set; }
        // helper properties for UI binding
        public bool IsThisStateOne { get { return CurrentState == AppState.StateOne; }
        public bool IsThisStateTwo { get { return CurrentState == AppState.StateTwo; }
        public bool IsThisStateThree { get { return CurrentState == AppState.StateThree; }
    }
