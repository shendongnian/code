    ?parentService.GetHashCode()
    45653674
    ?parentService2.GetHashCode()
    41149443
    //one service instance per resolve
    ?parentService.session.GetHashCode()
    39785641
    ?parentService2.session.GetHashCode()
    39785641
    //same DBSesion in every service resolved per HTTP request
    ?childService.GetHashCode()
    45523402
    ?childService.session.GetHashCode()
    35287174
    //new Service and DbSession per resolve
    ?childService2.GetHashCode()
    44419000
    ?childService2.session.GetHashCode()
    52697953
