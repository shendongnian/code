    @if(Model.Students != null && Model.Students.Any()){
        @Html.Partial("Partials/_Students", Model.Students)
    } else {
        @Html.Partial("Partials/_NoStudents")
    }
