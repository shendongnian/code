    private void RealizarSolicitacao(ParametrosExportacaoProdutos parametros, FilialDaConfiguracao filial)
    {                          
        Task<ResultadoExportacaoProdutos> task1 = Task<ResultadoExportacaoProdutos>.Factory.StartNew(() =>
        {
            return Servico.ExportarProdutosPorArquivo(parametros);
        });
        //The Result property blocks the calling thread until the task finishes.
        ResultadoExportacaoProdutos resultado = task1.Result;
    }
