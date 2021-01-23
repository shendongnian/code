    namespace Fusion.ContentTiles.Handlers {
    	[UsedImplicitly]
    	[OrchardFeature("Fusion.ContentTiles.TaxonomyExtensions")]
    	public class TaxonomyTileFieldHandler : ContentHandler {
    		private readonly IContentDefinitionManager _contentDefinitionManager;
    
    		public TaxonomyTileFieldHandler(
                IContentDefinitionManager contentDefinitionManager) {
	    		_contentDefinitionManager = contentDefinitionManager;
	    	}
    
    		protected override void Activating(ActivatingContentContext context) {
    			base.Activating(context);
    
    			// weld the TermsPart dynamically, if a field has been assigned to one of its parts
	    		var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(context.ContentType);
    			if (contentTypeDefinition == null) {
    				return;
    			}
    			if (contentTypeDefinition.Parts.Any(
    				part => part.PartDefinition.Fields.Any(
    					field => field.FieldDefinition.Name == typeof(TaxonomyTileField).Name))) {
    
    				context.Builder.Weld<TermsPart>();
    			}
    		}
    	}
    }
