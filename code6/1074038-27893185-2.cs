        public static CodeTypeReference CreateShortCodeTypeReference(Type type, CodeNamespaceImportCollection imports)
        {
            var result = new CodeTypeReference(type);
            Shortify(result, type, imports);
            return result;
        }
        private static void Shortify(CodeTypeReference typeReference, Type type, CodeNamespaceImportCollection imports)
        {
            if (typeReference.ArrayRank > 0)
            {
                Shortify(typeReference.ArrayElementType, type, imports);
                return;
            }
            if (type.Namespace != null && imports.Cast<CodeNamespaceImport>()
                .Any(cni => cni.Namespace == type.Namespace))
            {
                var prefix = type.Namespace + '.';
                if (prefix != null)
                {
                    var pos = typeReference.BaseType.IndexOf(prefix);
                    if (pos == 0)
                    {
                        typeReference.BaseType = typeReference.BaseType.Substring(prefix.Length);
                    }
                }
            }
        }
