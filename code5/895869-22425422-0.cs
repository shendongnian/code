	using Orchard.ContentManagement;
	using Orchard.ContentManagement.Records;
	using Orchard.Data;
	using Orchard.UI.Admin;
	using System.Linq;
	using System.Web.Mvc;
	namespace Orchard.Users.Controllers
	{
		[Admin]
		public class ContactFormEntryFixController : Controller
		{
			private readonly IRepository<ContentItemRecord> _contentItemRecords;
			private readonly IRepository<ContentItemVersionRecord> _contentItemVersionRecords;
			private readonly IContentManager _contentManager;
			private const int _contentTypeId = 26;
			public ContactFormEntryFixController(IRepository<ContentItemRecord> contentItemRecords, IRepository<ContentItemVersionRecord> contentItemVersionRecords, IContentManager contentManager)
			{
				_contentItemRecords = contentItemRecords;
				_contentItemVersionRecords = contentItemVersionRecords;
				_contentManager = contentManager;
			}
			public ActionResult Index()
			{
				var itemRecords = _contentItemRecords.Table.Where(record => record.ContentType.Id == _contentTypeId);
				var itemVersionRecords = _contentItemVersionRecords.Table.Where(versionRecord => itemRecords.Select(record => record.Id).Contains(versionRecord.ContentItemRecord.Id));
				foreach (var item in itemVersionRecords) item.Data = itemRecords.FirstOrDefault(record => record.Id == item.ContentItemRecord.Id).Data;
				var items = _contentManager.Query("ContactForm").List();
				foreach (var item in items) _contentManager.Unpublish(item);
				return Content(string.Format("{0} Contact Form version entry successfully fixed and {1} Contact Form item unpublished.", itemVersionRecords.Count(), items.Count()));
			}
		}
	}
