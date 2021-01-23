    public interface IAppearance
    {
        void updateAppearanceOf(Control control);
    }
    public abstract class Appearance<T> : IAppearance where T : Control 
    {
        void IAppearance.updateAppearanceOf(Control control)
        {
            if (control is T) updateAppearanceOf((T)control);
        }
        public abstract void updateAppearanceOf(T control);
    }
    public class TextBoxAppearance : Appearance<TextBox> {
        public override void updateAppearanceOf(TextBox control)
        {
            // implement update of TextBox
        }
    }
