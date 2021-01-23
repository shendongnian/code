    public class GrupoArquivoMap : ClassMap<GrupoArquivo> 
    {
        public GrupoArquivoMap()
        {
            Schema(Const.SCHEMA);
            Table(Const.TB_EMAIL_GRUPO_ARQUIVO);
            CompositeId()
                .KeyReference(x => x.Arquivo, Const.ID_ARQUIVO)
                .KeyReference(x => x.GrupoModulo, Const.ID_GRUPO, Const.ID_MODULO)
                ;
        }
    }
  
