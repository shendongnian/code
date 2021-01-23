    namespace MyNamespace {
        // Used by classes built by an ExcelQueryableFactory to permit 
        // initialization without knowledge of the underlying properties.
        public interface IExcelQueryable  {
            void BuildFrom(object[] data);
        }
    }
