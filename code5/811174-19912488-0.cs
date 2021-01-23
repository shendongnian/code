    public interface IAppearance
    {
        void Update(Control control);
    }
    
    public interface IAppearance<in TControl> : IAppearance
        where TControl : Control
    {
        void Update(TControl control);
    }
    
    public class TextBoxAppearance : IAppearance<TextBox>
    {
        void IAppearance.Update(Control control)
        {
            var textBox = control as TextBox;
            
            if(textBox == null) return;
            this.Update(textBox);
        }
        
        public void Update(TextBox control)
        {
            // Logic
        }
    }
