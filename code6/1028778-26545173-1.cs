    public class myViewModel : ViewModel, IRevertState {
    public bool CanRevertState() {
        return (...) //condition under which back navigation should be disabled
    }
    public void RevertState() {
        (...) // optionally reset condition if required
    }
