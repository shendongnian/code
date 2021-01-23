     internal virtual int? DetermineParameterSize(SqlType declaredType, DbParameter parameter) {
            // Output parameters and input-parameters of a fixed-size should be specifically set if value fits.
            bool isInputParameter = parameter.Direction == ParameterDirection.Input;
            if (!isInputParameter || declaredType.IsFixedSize) {
                if (declaredType.Size.HasValue && parameter.Size <= declaredType.Size || declaredType.IsLargeType) {
                    return declaredType.Size.Value;
                }
            }
        
            // Preserve existing provider & server-driven behaviour for all other cases.
            return null;
        }
        
        protected int? GetLargestDeclarableSize(SqlType declaredType) {
                switch (declaredType.SqlDbType) {
                case SqlDbType.Image:
                case SqlDbType.Binary:
                case SqlDbType.VarChar:
                    return 8000;
                case SqlDbType.NVarChar:
                    return 4000;
                default:
                    return null;
            }
        }
        internal virtual int? DetermineParameterSize(SqlType declaredType, DbParameter parameter) {
        // Output parameters and input-parameters of a fixed-size should be specifically set if value fits.
        bool isInputParameter = parameter.Direction == ParameterDirection.Input;
        if (!isInputParameter || declaredType.IsFixedSize) {
            if (declaredType.Size.HasValue && parameter.Size <= declaredType.Size || declaredType.IsLargeType) {
                return declaredType.Size.Value;
            }
        }
    
        // Preserve existing provider & server-driven behaviour for all other cases.
        return null;
    }
