    ?parentService.GetHashCode()
    62476613
    ?parentService2.GetHashCode()
    11404313
    //new IService in every Resolve in parent
    ?parentService.session.GetHashCode()
    64923656
    ?parentService2.session.GetHashCode()
    64923656
    //same IDbSession in the two IServices from parent resolve
    ?childService.GetHashCode()
    44624228
    ?childService.session.GetHashCode()
    17654054
    //a new IService and a new IDbSession in every resolve in child
