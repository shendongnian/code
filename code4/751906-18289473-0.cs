      private void SaveNewCommande(YetiBddEntities contexte, Excel.Application xlApp, Excel.Workbook xlWorkBook, string path, object misValue)
        {
            string tmpPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EcoEtech_Commande_Fournisseur";
            if (!Directory.Exists(tmpPath))
            {
                Directory.CreateDirectory(tmpPath);
            }  
            foreach (string file in Directory.GetFiles(tmpPath))
            {
                if ((path+".xls").Equals(file.Substring(tmpPath.Length+1)))
                    count++;
            }
            if (count>0)
                xlWorkBook.SaveAs(string.Format("EcoEtech_Commande_Fournisseur\\{0}_({1}).xls", path, count), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            else
                xlWorkBook.SaveAs(string.Format("EcoEtech_Commande_Fournisseur\\{0}.xls", path) + path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\EcoEtech_Commande_Fournisseur\\" + path+".xls";
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            this.ReleaseComObject(xlApp,xlWorkBook);
            //sauvergarde dans la base de données
            _newAchatCommande.path = path;
            this._fileName = path;
            contexte.AddToAchatCommande(_newAchatCommande);
            contexte.SaveChanges();
        }
