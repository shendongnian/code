        if (results.Errors.HasErrors)
        {
                StringBuilder sb = new StringBuilder();
    
                foreach (CompilerError error in results.Errors)
                {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }
    
                throw new InvalidOperationException(sb.ToString());
        }
