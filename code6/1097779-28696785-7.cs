    @model Exams.ViewModels.SubjectsViewModel
    @{
        ViewBag.Title = "Subjects"
    }
    <h2> Current Subjects </h2>
    @using (Html.BeginForm()) 
    {
        <table>
            @foreach(var subject in Model.Subjects){
                <tr>
                    <td>
                        @subject.Title</br>
                        @subject.Desc
                    </td>
                    <td>
                        <input name="submit" value='@subject.id'> Submit </button>
                    </td>
                <tr>
            }
        </table>
    }
