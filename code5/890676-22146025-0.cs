    foreach (var sectionItem in Model.CourseSections)
    {                     
      <li>
        <h5 class="accordion-title">@sectionItem.Title<span class="accordion-icon"></span></h5>
          <div class="accordion-content">
            <ul>                                    
            @foreach (var subSectionItem in sectionItem.SectionContents.OrderBy(sc => sc.ContentOrder)
            {
              <li><a href="#" id="menuItem @subSectionItem.ContentID @sectionItem.CourseSectionID" onclick="SubItemMenu(id)">@subSectionItem.Content.Name</a></li> 
            }
            </ul>
          </div>
      </li>
    }
