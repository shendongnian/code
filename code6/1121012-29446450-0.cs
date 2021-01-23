    public enum yesNo
    {
        Yes = 0,
        No = 1
    }
    public class TestModel
    {
        public TestModel()
        {
            // set default value in constructor
            this.Member_Addiction = yesNo.No;
        }
        [DisplayName("Do you have addiction?")]        
        public yesNo Member_Addiction { get; set; }
     }
    <div class="form-group">
           @Html.LabelFor(model => model.Member_Addiction, new { @class = "  col-md-3" })
           <div class="col-md-4">
                 @foreach (var e in Enum.GetValues(typeof(TestProject.Models.yesNo)))
                 {
                       <label class="radio-inline">
