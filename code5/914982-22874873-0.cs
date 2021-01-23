    public class ContactController : ApiController
    {
        static readonly IContactsRepository repository = new ContactsRepository();
        // GET api/Contact
        public IEnumerable<Contact> GetContact()
        {
            return repository.GetAll();
        }
        // GET api/Contact/5
        public IHttpActionResult GetContact(int id)
        {
            var contact = repository.Get(id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }
