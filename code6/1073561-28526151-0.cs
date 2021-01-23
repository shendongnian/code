    /// <summary>
    /// Extends Caliburn.Micro.IWindowManager functionalities, such as blinking windows.
    /// </summary>
    public interface IWindowManager : Caliburn.Micro.IWindowManager
    {
        void Blink(object rootModel);
    }
