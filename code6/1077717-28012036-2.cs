    @model IEnumerable<vergelijkCuracao.Models.Student>
    
    @foreach (var item in Model)
    {
        <h2> Student : @item.FirstName @item.LastName</h2>
        if (item.Enrollments != null)
        {
            foreach (var i in item.Enrollments)
            {
                <h2> Course : @i.course.CourseName</h2>
            }
        }
    
    }
