    public enum yesNo
    {
        Yes = 0,
        No = 1
    }
    public class TestModel
    {
        public TestModel()
        {
            this.Member_Addiction = false;
        }
        [DisplayName("Do you have addiction?")]        
        public bool Member_Addiction { get; set; }
    }
    @using (Html.BeginForm())
    {
        <div class="form-group">
            @Html.LabelFor(model => model.Member_Addiction, new { @class = "  col-md-3" })
            <div class="col-md-4">
                @foreach (TestProject.Models.yesNo e in Enum.GetValues(typeof(TestProject.Models.yesNo)))
                {
                    <label class="radio-inline">
                        @{ if (e == TestProject.Models.yesNo.No)
                           {
                            @Html.RadioButtonFor(model => model.Member_Addiction, false)@e.ToString() 
                           }
                           else
                           {
                            @Html.RadioButtonFor(model => model.Member_Addiction, true)@e.ToString() 
                           }
                        }
                    </label>
                }
            </div>
            @Html.ValidationMessageFor(model => model.Member_Addiction)
        </div>
        <button type="submit">OK</button>
    }
