    @{
      int I = 0;
      for(I=0; I < dropdowndepts.Length; I++){
        var depts = iStar.GetDepts() ;
        <li class="header header_@I">
          @foreach(var dept in depts){
            <li>@dept.Name</li>
          }
        </li>
      }
    }
