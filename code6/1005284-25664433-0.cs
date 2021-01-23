    wsSascar2.SasIntegraWSClient w2 = new wsSascar2.SasIntegraWSClient();
    List<wsSascar2.pacotePosicao> lista  = new List<wsSascar2.pacotePosicao>(); 
    var result = w2.obterPacotePosicoes("user", "password", 0);
    if(result != null)
       lista  = result.ToList(); 
