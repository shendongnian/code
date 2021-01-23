    using System;
    using System.Web.Http.OData;
    
    namespace ReproPatchNotWork.Models
    {
        public class AnnouncementsController : EntitySetController<Announcement, Guid>
        {
            protected override Announcement PatchEntity(Guid key, Delta<Announcement> patch)
            {
                Announcement announcement = new Announcement();
                patch.Patch(announcement);
                return announcement;
            }
        }
    }
