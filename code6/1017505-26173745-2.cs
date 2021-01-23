    doc = explorer.GetType().InvokeMember("ActiveInlineResponseWordEditor",
                                     System.Reflection.BindingFlags.GetProperty | 
                                     System.Reflection.BindingFlags.Instance |
                                     System.Reflection.BindingFlags.Public, 
                                     null, explorer, null) as Word.Document;
