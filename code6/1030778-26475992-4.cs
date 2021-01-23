    @model NotesVM
    ....
    @using (Html.BeginForm())
    {
      @Html.EditorFor(m => m.NewNote.Text)
      <input type="submit" value="Create" class="btn btn-default" />
    }
    ....
    <ul>
      @foreach (var d in Model.NotesList)
      {
        <li>@d.Text</li>
      }
    </ul>
