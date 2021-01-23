    public class ApplicationService : IApplicationService
    {
        
        public string GetURL()
        {
                
            return Clipboard.GetText(TextDataFormat.Text);
        }
    }
