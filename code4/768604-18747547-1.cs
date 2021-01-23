    @{
      int i = 0;
      foreach (var item in Model.IPACS_Processes.IPACS_Procedures)
      {
        <!-- stuff and stuff --!>
        if(i > 0) {
                <a href="" class="btn btn-small"><span class="iconfa-double-angle-up icon-    white">
                </span>Move Up</a>
        }
        if(i < Model.IPACS_Processes.IPACS_Procedures.Count)
        {
                <a href="" class="btn btn-small"><span class="iconfa-double-angle-down">     </span>
                    Move Down</a>
        }
        i++;
      }
    }
