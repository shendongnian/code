    @model IEnumerable<Project.Web.ViewModels.SampleModel>
    @foreach (item in Model) {
       <p><b>ID:</b> @item.id</p>
       <p><b>FirstName:</b> @item.GetData("firstname")</p>
       <p><b>LastName:</b> @item.GetData("lastname")</p>
       <br>
    }
