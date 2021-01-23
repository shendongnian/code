        private static void Cleanup(object x, string tmpPath, Word.ApplicationClass app, Word.Document doc)
        {
            Clipboard.Clear();
            object Save = false;
            (doc as Word._Document).Close(ref Save, ref x, ref x);
            doc = null;
            (app as Word._Application).Quit();
            app = null;
            try { File.Delete(tmpPath); }
            catch { }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
