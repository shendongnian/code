        public HttpResponseMessage GetOrder()
        {
            // Sample object data
            Order order = new Order();
            order.Id = "A100";
            order.OrderedDate = DateTime.Now;
            order.OrderTotal = 150.00;
       
            // Explicitly override content negotiation and return XML
            return Request.CreateResponse<Order>(HttpStatusCode.OK, order, Configuration.Formatters.XmlFormatter);
        }
