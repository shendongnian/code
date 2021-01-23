    @model List<MyProgram.Models.Document>
    @{
        ViewBag.Title = "View1";
    }
    @foreach (MyProgram.Models.Document doc in Model)
    {
        <p>doc.Content</p>
    }
