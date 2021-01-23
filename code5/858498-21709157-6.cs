        private IMappingEngine mappingEngine
        {
            get
            {
                if (_mappingEngine == null)
                {
                    _mappingEngine = AutoMapper.Mapper.Engine;
                }
                return _mappingEngine;
            }
        }
