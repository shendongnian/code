    public List<Label> GetLabelsOrderedByCustomerId(string customerId)
    {
        using (var uow = new UnitOfWork(connectionString))
        {
            _labelRepository.Context = uow.Context;
            _orderLineRepository.Context = uow.Context;
            var labels = (from ol in _orderLineRepository.GetAll()
                join l in _labelRepository.GetAll() on new {ol.QualityId, ol.CustomerId, ol.SerialNumber} equals
                    new {l.QualityId, l.CustomerId, l.SerialNumber}
                where ol.OrderCustomer == customerId
                select l).Distinct().ToList();
            return labels;   
        }
    }
