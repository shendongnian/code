        public virtual void FecharDocumento(Word.Document doc, Word.Application word)
        {
            System.Threading.Thread.Sleep(1000);
            doc.Close(oFalse, oMissing, oMissing);
            word.Quit(oFalse, oMissing, oMissing);
            Marshal.FinalReleaseComObject(doc);
            Marshal.FinalReleaseComObject(word);
        }
