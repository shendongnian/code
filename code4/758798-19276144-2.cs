        public virtual void PreencherDocumentoPorObjetoETexto(Dictionary<string, string> listaDeParametros, Word.Document doc)
        {
            foreach (Shape shape in doc.Shapes)
            {
                foreach (string key in listaDeParametros.Keys)
                {
                    if (shape.TextFrame.TextRange.Text.Contains(key))
                        shape.TextFrame.TextRange.Text = listaDeParametros[key];
                }
            }
            foreach (string key in listaDeParametros.Keys)
            {
                Word.Find findObject = doc.Application.Selection.Find;
                findObject.ClearFormatting();
                findObject.Text = key;
                findObject.Replacement.ClearFormatting();
                findObject.Replacement.Text = listaDeParametros[key];
                object replaceAll = Word.WdReplace.wdReplaceAll;
                findObject.Execute(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref replaceAll, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            }
        }
