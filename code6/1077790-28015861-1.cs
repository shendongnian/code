    public class UnitTest1
    {
        public void ShouldCompile()
        {
            IListener<IChange> listener = new ChangeListener();
        }
    }
	
	public interface IListener<out T> {}
    public abstract class BaseListener<T> : IListener<T>
    where T : IChange
    {       
    }
