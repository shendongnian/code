        public GenericEntityController(IGenericLogic<S> logic, ICustomMapping customMapping)
            : base()
        {
            this._mappingEngine = customMapping.MappingEngine;
            this.logic = logic;
        }
