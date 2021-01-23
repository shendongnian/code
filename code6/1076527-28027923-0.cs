    @using Orchard.ContentManagement
    @using Orchard.Core.Common.Models
    @using Orchard.Core.Containers.Extensions;
    @{
        var item = Model.ContentItem;
        var part = (Orchard.Core.Containers.Models.ContainerWidgetPart)Model.ContentItem.ContainerWidgetPart;
    
        var _contentManager = WorkContext.Resolve<IContentManager>();
        var container = _contentManager.Get(part.Record.ContainerId);
    
        IContentQuery<ContentItem> query = _contentManager
            .Query(VersionOptions.Published)
            .Join<CommonPartRecord>().Where(cr => cr.Container.Id == container.Id);
    
        if (part.Record.ApplyFilter) {
            query = query.Where(part.Record.FilterByProperty, part.Record.FilterByOperator, part.Record.FilterByValue);
        }
    
        var items = query.Slice(0, part.Record.PageSize).ToList();
        
    }
    
    @foreach (var i in items) {
        // do stuff with the item here
    }
