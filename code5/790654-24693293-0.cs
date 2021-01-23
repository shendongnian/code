      public static void AddChildTypeDeclaration(
            this AstNode tree, 
            TypeDeclaration newClass,
            NamespaceDeclaration parentNamespace = null)
        {
            if (null != parentNamespace)
            {
                var newNamespaceNode = new NamespaceDeclaration(
                    parentNamespace.Name);
                newNamespaceNode.AddMember(newClass);
                tree.AddChild(newNamespaceNode, SyntaxTree.MemberRole);
            }
            else
            {
                tree.AddChild(newClass, Roles.TypeMemberRole);
            }
        }
