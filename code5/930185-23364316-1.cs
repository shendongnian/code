    public class ExpandNVelocityTokens
    {
        public virtual void Process(RenderFieldArgs args)
        {
            if (!ShouldRun())
                return;
            
            if (!Sitecore.Context.PageMode.IsPageEditorEditing)
            {
                args.Result.FirstPart = ExpandVelocityTokens(args.Result.FirstPart);
                args.Result.LastPart = ExpandVelocityTokens(args.Result.LastPart);
            }
        }
        protected bool ShouldRun()
        {
            // In the cheapest possible way - determine if we need to do anything
        }
        protected string ExpandVelocityTokens(string input)
        {
            //... do velocity stuff here
        }
    }
