    public interface IActionRunner {
        void ExecIfNotCancelled(CancellationToken token, Action action);
    }
    public class ActionRunner : IActionRunner{
        public void ExecIfNotCancelled(CancellationToken token, Action action) {
            token.ThrowIfCancellationRequested();
            action();
        }
    }
