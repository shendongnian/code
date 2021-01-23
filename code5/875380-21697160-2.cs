    public object GetService(Type serviceType)
    {
        if (serviceType == typeof (LabelsController)) {
            var labelRepo = new LabelRepository();
            var orderRepo = new OrderLineRepository(labelRepo.Context);
            return new LabelsController(
                new LabelService(labelRepo, orderRepo),
                new OrderLineService(orderRepo)
            );
        }
        return null;
    }
