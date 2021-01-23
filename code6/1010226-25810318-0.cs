    for (int iterator=0; iterator < 10; iterator++)
    {
        int i = iterator;
        listTask[iterator] = Task.Factory.StartNew(() =>
        {
            Int32 send = i + page * 10;
            DoStatus("Page: " + send.ToString());
            Processamento(parametros, filial, send);                        
        });
    }
