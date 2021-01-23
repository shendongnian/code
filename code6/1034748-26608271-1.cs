    // In Bootstrapper class
    resolver.RegisterInstance<IDataTypeFactory>(new DataTypeFactory(resolver));
    resolver.RegisterType<DataType1>();
    resolver.RegisterType<DataType2>();
    resolver.RegisterType<DataType3>();
    private sealed class DataTypeFactory : IDataTypeFactory {
        private readonly IUnityContainer container;
        public DataTypeFactory(IUnityContainer container) {
            this.container = container;
        }
        public IDataType Create(DataRecordType dataRecordType) {
            switch (dataRecordType) {
                case DataRecordType.dataType1:
                    return this.container.Resolve<DataType1>();
                case DataRecordType.dataType2:
                    return this.container.Resolve<DataType2>();
                case DataRecordType.dataType3:
                    return this.container.Resolve<DataType3>();
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
