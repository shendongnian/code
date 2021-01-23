    $/ = undef;
    
    $str = <DATA>;
    
    while ( $str =~ /(?ms)^(?<data>[^\[\]\r\n]+)[ \t]+\[(?<thread>[0-9]+)\][ \t]+(?<nivel>[A-Z]+)[ \t]+(?<classe>(?:[A-Za-z]+\.)+[A-Za-z]+)[ \t]+-[ \t]+(?<message>(?:(?!^[^\[\]\r\n]+[ \t]+\[[0-9]+\]).)+)/g )
    {
        print "----------------------\n";
        print "New Exception\n";
        print "Data:\t$1\n";
        print "Thread:\t$2\n";
        print "Err:\t$3\n";
        print "Class:\t$4\n";
        print "Msg -- \n";
        print "$5\n";
    
    }
    
    
    __DATA__
    
    2014-02-13 16:06:52,226 [8] ERROR solucao.projeto.arquivo - AutenticarUsuario
    System.Threading.ThreadAbortException: O thread estava sendo anulado.
        em System.Threading.Thread.AbortInternal()
        em System.Threading.Thread.Abort(Object stateInfo)
        em System.Web.HttpResponse.End()  
    2014-02-13 16:06:52,226 [8] ERROR solucao.projeto.arquivo - AutenticarUsuario
    System.Threading.ThreadAbortException: O thread estava sendo anulado.
       em System.Threading.Thread.AbortInternal()
       em System.Threading.Thread.Abort(Object stateInfo)
       em System.Web.HttpResponse.End()
