    public class UmbracoActionsHandler : IApplicationStartupHandler
        {
            public UmbracoActionsHandler()
            {
                Media.AfterMoveToTrash += Media_AfterMoveToTrash;
            }
    
            void Media_AfterMoveToTrash(Media sender, umbraco.cms.businesslogic.MoveToTrashEventArgs e)
            {
                ......
            }
        }
