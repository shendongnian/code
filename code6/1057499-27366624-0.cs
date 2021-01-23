        public GrupoArquivo() {}
        public GrupoArquivo(ArquivoRetorno arquivoRetorno, GrupoModulo grupoModulo) : this()
        {
            Arquivo = arquivoRetorno;
            GrupoModulo = grupoModulo;
        }
        public virtual ArquivoRetorno Arquivo { get; protected set; }
        public virtual GrupoModulo GrupoModulo { get; protected set; }
 
        public override bool Equals(object obj)
        {
            var grupoArquivo = (obj as GrupoArquivo);
            if (grupoArquivo != null)
            {
                if (ReferenceEquals(obj, this))
                    return true;
                var thisHash = GetHashCode();
                var otherHash = grupoArquivo.GetHashCode();
                return thisHash.Equals(otherHash);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return string.Concat("{0}|{1}|{2}", Arquivo, GrupoModulo).GetHashCode();
        }
