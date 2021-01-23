    namespace Microsoft.SqlServer.Dts.Pipeline
    {
        public class ScriptBuffer
        {
            protected PipelineBuffer Buffer;
            protected int[] BufferColumnIndexes;
    
            public ScriptBuffer(PipelineBuffer BufferToUse, int[] BufferColumnIndexesToUse, OutputNameMap OutputMap);
    
            protected object this[int ColumnIndex] { get; set; }
    
            protected void AddRow();
            protected void DirectRow(string outputName);
            protected bool EndOfRowset();
            protected bool IsNull(int ColumnIndex);
            protected bool NextRow();
            protected void SetEndOfRowset();
            protected void SetNull(int ColumnIndex);
        }
    }
