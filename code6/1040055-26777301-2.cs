      @model IEnumerable<YourApplication.Models.Course>
      
    
          <ul>
            @foreach(YourApplication.Models.Course detail in Model)
            {
               <li>@detail.Name</li>
            }
            </ul>
