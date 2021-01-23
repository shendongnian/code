    switch (x.GetType().GetTypeCode()) {
        // put all TypeCodes that you consider scalars here:
        case TypeCode.Boolean:
        case TypeCode.Int16:
        case TypeCode.Int32:
        case TypeCode.Int64:
        case TypeCode.String:
            // scalar type
            break;
        default:
            // not a scalar type
    }
