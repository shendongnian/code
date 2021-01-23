    internal override bool IsFixedSize {
        get {
            switch (this.sqlDbType) {
                case SqlDbType.NText:
                case SqlDbType.Text:
                case SqlDbType.NVarChar:
                case SqlDbType.VarChar:
                case SqlDbType.Image:
                case SqlDbType.VarBinary:
                case SqlDbType.Xml:
                    return false;
                default:
                    return true;
            }
        }
    }
