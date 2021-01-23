    private class TestUpdateMacActivityPriorityTranslator : UpdateMacActivityPriorityTranslator
    {
        public CSUpdateMACActivityPriorityResponseType TestBusinessToService(IEntityTranslatorService service, object value)
        {
            return this.BusinessToService(service, value);
        }
    }
