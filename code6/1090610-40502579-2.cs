        @model ExampleViewModel
        @using (Html.BeginForm())
        {
            <table class="table table-bordered table-striped">
                @for(int i=0;i<Model.Questions.Count;i++)
                {
                    var question = Model.Questions[i];
                    <tr>
                        <td>
                            @foreach (var answer in question.Value)
                            {
                                <input type="text" name="Model.Answers[@question.Key].Key" value="@question.Key" />
                                <input type="hidden" name="Model.Answers.Index" value="@question.Key" />
                                @Html.RadioButton("Model.Answers[" + question.Key+"].Value", answer, false) @answer
                            }
                        </td>
                    </tr>
                }
                <tr>
                    <td>
                        <input type="submit" class="btn btn-primary" value="Submit" />
                    </td>
                </tr>
            </table>
        }
