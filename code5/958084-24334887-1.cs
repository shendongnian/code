    public class UpdateBackgroundMessage : MessageBase
    {
        public UpdateBackgroundMessage(Brush brush)
        {
            Brush = brush;
        }
        public Brush Brush { get; set; }
    }
