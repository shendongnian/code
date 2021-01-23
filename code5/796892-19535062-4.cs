    public class LimitByTemplateTask : IObjectConstructionTask
    {
        private static readonly Type _templateCheck = typeof (ITemplateCheck);
        public void Execute(ObjectConstructionArgs args)
        {
            if (args.Result != null)
                return;
            if ( _templateCheck.IsAssignableFrom(args.AbstractTypeCreationContext.RequestedType))
            {
                var scContext = args.AbstractTypeCreationContext as SitecoreTypeCreationContext;
                var config = args.Configuration as SitecoreTypeConfiguration;
                var template = scContext.SitecoreService.Database.GetTemplate(scContext.Item.TemplateID);
                //check to see if any base template matched the template for the requested type
                if (template.BaseTemplates.All(x => x.ID != config.TemplateId) && scContext.Item.TemplateID != config.TemplateId)
                {
                    args.AbortPipeline();
                }
            }
        }
    }
    public interface ITemplateCheck{}
