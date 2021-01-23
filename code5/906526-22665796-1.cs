    public class TestModel
    {
        [DataType(DataType.Time)]
        public DateTime MyTime { get; set; }
    }
    @Html.EditorFor(model => model.MyTime)
