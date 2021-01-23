    class CRUDController<T> : ApiController
    {
        public virtual HttpResponseMessage Get(int id=-1) { // do the read operation }
        public virtual HttpResponseMessage Post(T obj) { // do the create operation }
        public virtual HttpResponseMessage Put(T obj) { // do the update operation }
        public virtual HttpResponseMessage Delete(T obj) { // do the delete operation }
    }
