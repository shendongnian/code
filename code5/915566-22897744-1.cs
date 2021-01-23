    @model IList<GroupViewModel>
    
    @for (int i = 0; i < Model.Count; i++)
    {
     <h4>Model[i].Code</h4>
    
     <select id="e-@i" multiple="multiple">
     @foreach (Subject subject in Model[i].AllSubjects)
     {
      <option value="@subject.Name">@subject.Name</option>
     }
     </select>
    }
