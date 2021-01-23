        /// <remarks>
        /// TypedConstant isn't computing its own kind from the type symbol because it doesn't
        /// have a way to recognize the well-known type System.Type.
        /// </remarks>
        internal static TypedConstantKind GetTypedConstantKind(ITypeSymbol type, Compilation compilation)
        {
            Debug.Assert(type != null);
 
            switch (type.SpecialType)
            {
                case SpecialType.System_Boolean:
                case SpecialType.System_SByte:
                case SpecialType.System_Int16:
                case SpecialType.System_Int32:
                case SpecialType.System_Int64:
                case SpecialType.System_Byte:
                case SpecialType.System_UInt16:
                case SpecialType.System_UInt32:
                case SpecialType.System_UInt64:
                case SpecialType.System_Single:
                case SpecialType.System_Double:
                case SpecialType.System_Char:
                case SpecialType.System_String:
                case SpecialType.System_Object:
                    return TypedConstantKind.Primitive;
                default:
                    switch (type.TypeKind)
                    {
                        case TypeKind.Array:
                            return TypedConstantKind.Array;
                        case TypeKind.Enum:
                            return TypedConstantKind.Enum;
                        case TypeKind.Error:
                            return TypedConstantKind.Error;
                    }
 
                    if (compilation != null &&
                        compilation.IsSystemTypeReference(type))
                    {
                        return TypedConstantKind.Type;
                    }
 
                    return TypedConstantKind.Error;
            }
        }
