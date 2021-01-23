    // In your core layer
    public interface IDataType {
        void ProcessData();
    }
    public interface IDataTypeFactory {
        IDataType Create(DataRecordType dataRecordType);
    }
    // In Bootstrapper class
    resolver.RegisterInstance<IDataTypeFactory>(new DataTypeFactory(resolver));
    resolver.RegisterType<IDataType1, DataType1>();
    resolver.RegisterType<IDataType2, DataType2>();
    resolver.RegisterType<IDataType3, DataType3>();
    private sealed class DataTypeFactory : IDataTypeFactory {
        private readonly IUnityContainer container;
        public DataTypeFactory(IUnityContainer container) {
            this.container = container;
        }
        public IDataType Create(DataRecordType dataRecordType) {
            switch (dataRecordType) {
                case DataRecordType.dataType1:
                    return this.container.Resolve<IDataType1>();
                case DataRecordType.dataType2:
                    return this.container.Resolve<IDataType2>();
                case DataRecordType.dataType3:
                    return this.container.Resolve<IDataType3>();
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
