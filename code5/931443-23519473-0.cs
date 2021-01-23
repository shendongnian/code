    interface IDataCellAnnotation
    {
        // Some annotations for a data cell ...
    }
    interface IAnnotatedTable
    {
        IEnumerable<IDataCellAnnotation> GetCellAnnotations(System.Data.DataRow row);
    }
    class AnnotatedDataTable : DataTable, IAnnotatedTable
    {
        // ...
        public IEnumerable<IDataCellAnnotation> GetCellAnnotations(System.Data.DataRow row)
        {
            return theAnnotationsForTheGivenRow;
        }
    }
