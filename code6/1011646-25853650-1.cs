    public class ReadFileOperation : IOperation
    {
        [Parameter]
        public string Filename { get; set; }
        public Type InputType { get { return null; } } // No input
        public Type OutputType { get { return typeof(DataTable); } }
        public object GetOutput(object input)
        {
            // TODO: Read file into DataTable here!
        }
    }
