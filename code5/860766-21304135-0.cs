    abstract public class HtmlTemplateBuilder
    {
        HtmlSource source;
        object locker = new object();
        private bool initialised;
    
        protected HtmlTemplateBuilder()
        {
        }
    
        protected void Initialise()
        {
            lock (locker)
            {
                if(initialised)
                {
                    LoadTemplates();
                    initialised = true;
                }
            }
        }
    
        public abstract void LoadTemplates();
    }
