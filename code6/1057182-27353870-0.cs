    LinkCollection links = tfsProblem.workitem1.Links;
    if (!links.Any(x => ((Microsoft.TeamFoundation.WorkItemTracking.Client.RelatedLink) (x)).RelatedWorkItemId == tfsEvent.workitem2.Id)
    {
       WorkItemLinkType linkType = wis.WorkItemLinkTypes[CoreLinkTypeReferenceNames.Related];
       tfsProblem.workitem1.Links.Add(new WorkItemLink(linkType.ForwardEnd, tfsEvent.workitem2.Id));
       tfsProblem.workitem1.Save();
    }
