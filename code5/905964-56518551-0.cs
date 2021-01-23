    public interface ISoundPlayer
    {
      event Action Play();
    }    
    
    public class MyViewModel : ViewModelBase, ISoundPlayer
    {
      public event Action Play;
    }
