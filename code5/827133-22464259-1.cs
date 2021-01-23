    using AutoMapper;
    using Fss.Areas.Customers.Models;
    using Fss.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    namespace Fss.Areas.Customers.Controllers
    {
        public class ContactsController : Controller
        {
            FssData.EntitiesModel _DbContext;
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Create([DataSourceRequest]
                                       DataSourceRequest request, Contact contact, int id)
            {
                if (contact != null && this.ModelState.IsValid)
                {
                    var currentDateTime = this._DbContext.GetDateTime();
                    var customer = this._DbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
                    if (customer != null)
                    {
                        var dataContact = Mapper.Map(contact, new FssData.Contact());
                        dataContact.CustomerId = customer.CustomerId;
                        dataContact.SyncId = Guid.NewGuid();
                        dataContact.Created = currentDateTime;
                        dataContact.CreatedBy = this.User.Identity.Name;
                        dataContact.Changed = currentDateTime;
                        dataContact.ChangedBy = this.User.Identity.Name;
                        this._DbContext.Add(dataContact);
                        this._DbContext.SaveChanges();
                        Mapper.Map(dataContact, contact);
                    }
                }
                return this.Json(new[]
                                 {
                                     contact
                                 }.ToDataSourceResult(request, this.ModelState));
            }
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Delete([DataSourceRequest]
                                       DataSourceRequest request, Contact contact)
            {
                if (contact != null && this.ModelState.IsValid)
                {
                    var dataContact = this._DbContext.Contacts.FirstOrDefault(c => c.ContactId.Equals(contact.ContactId));
                    if (dataContact != null)
                    {
                        this._DbContext.Delete(dataContact);
                        this._DbContext.SaveChanges();
                    }
                }
                return this.Json(new[]
                                 {
                                     contact
                                 }.ToDataSourceResult(request, this.ModelState));
            }
            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Edit([DataSourceRequest]
                                     DataSourceRequest request, Contact contact)
            {
                if (contact != null && this.ModelState.IsValid)
                {
                    var currentDateTime = this._DbContext.GetDateTime();
                    var dataContact = this._DbContext.Contacts.FirstOrDefault(c => c.ContactId.Equals(contact.ContactId));
                    if (dataContact != null)
                    {
                        Mapper.Map(contact, dataContact);
                        dataContact.Changed = currentDateTime;
                        dataContact.ChangedBy = this.User.Identity.Name;
                        this._DbContext.SaveChanges();
                        Mapper.Map(dataContact, contact);
                    }
                }
                return this.Json(new[]
                                 {
                                     contact
                                 }.ToDataSourceResult(request, this.ModelState));
            }
            public ActionResult Customer(int id)
            {
                return this.View();
            }
            public ActionResult GetCustomers()
            {
                return this.Json(this._DbContext.Customers.Select(c => new { Name = c.Name, CustomerId = c.CustomerId }), JsonRequestBehavior.AllowGet);
            }
            public ActionResult Index()
            {
                var customer = this._DbContext.Customers.FirstOrDefault();
                return this.RedirectToAction(actionName: "Customer", routeValues: new { id = customer != null ? customer.CustomerId : 0 });
            }
  
            public ActionResult Read([DataSourceRequest]
                                     DataSourceRequest request)
            {
                return this.Json(this._DbContext.Contacts.Select(c => Mapper.Map<Contact>(c)).ToDataSourceResult(request));
            }
            protected override void Initialize(RequestContext requestContext)
            {
                this._DbContext = ContextFactory.GetContextPerRequest();
                base.Initialize(requestContext);
            }
        }
    }
