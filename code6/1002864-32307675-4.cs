    namespace ProjectBar.Controls
    {
        public class CustomControl : ContentControl
        {
            static CustomControl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), new FrameworkPropertyMetadata(typeof(CustomControl)));
            }
        }
    }
