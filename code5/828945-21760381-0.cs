    class ConstantsSerializer<t> : CodeDomSerializer
    {
     public override object Serialize(IDesignerSerializationManager manager, object value)
     {
      ConstantsExtenderProvider provider = value as ConstantsExtenderProvider;
     
      CodeDomSerializer baseClassSerializer = manager.GetSerializer(typeof(ConstantsExtenderProvider).BaseType, typeof(CodeDomSerializer)) as CodeDomSerializer;
      CodeStatementCollection statements = baseClassSerializer.Serialize(manager, value) as CodeStatementCollection;
     
      IDesignerHost host = (IDesignerHost)manager.GetService(typeof(IDesignerHost));
      ComponentCollection components = host.Container.Components;
      this.SerializeExtender(manager, provider, components, statements);
     
      return statements;
     }
     
     private void SerializeExtender(IDesignerSerializationManager manager, ConstantsExtenderProvider provider, ComponentCollection components, CodeStatementCollection statements)
     {
      foreach (IComponent component in components)
      {
       Control control = component as Control;
       if (control != null && (control as Form == null))
       {
        CodeMethodInvokeExpression methodcall = new CodeMethodInvokeExpression(base.SerializeToExpression(manager, provider), "SetConstants");
        methodcall.Parameters.Add(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), control.Name));
     
        string[] constants = provider.GetConstants(control);
        if (constants != null)
        {
         StringBuilder sb = new StringBuilder();
         sb.Append("new string[] { ");
     
         foreach (string constant in constants)
         {
          sb.Append(typeof(T).FullName);
          sb.Append(".");
          sb.Append(constant);
          sb.Append(", ");
         }
     
         sb.Remove(sb.Length - 2, 2);
         sb.Append(" }");
     
         methodcall.Parameters.Add(new CodeSnippetExpression(sb.ToString()));
        }
        else
        {
         methodcall.Parameters.Add(new CodePrimitiveExpression(null));
        }
     
        statements.Add(methodcall);
       }
      }
     }
    }
