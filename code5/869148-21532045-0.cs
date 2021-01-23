    public void inserir_tabela(int numero_de_linhas, int numero_de_colunas) // insert table, here live my problema
    {
        Word.Range range = w_doc.Range(ref missing, ref missing);
        Word.Table myTable = range.Tables.Add(range, numero_de_linhas, numero_de_colunas);
        myTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        myTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
    }
