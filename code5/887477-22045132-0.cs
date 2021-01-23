    public class ClientModel
    {
        public int ClientId {get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    var model = from c in clients
                select new ClientModel {
                   ...
                };
    return View(new GridModel(model));
