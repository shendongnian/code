        <ul>
            @foreach(Notes note in Model)
            {
               <li>
                   @Html.ActionLink(note.ProductID.ToString(), "Details", new { id = note.ID })
               </li> 
            }
        </ul>
