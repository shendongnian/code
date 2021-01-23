            bool bFichierExiste = false;
            string sPhrase = "";
            
            bFichierExiste = File.Exists("ecrire.txt"); 
            if (!bFichierExiste)
            {
                MessageBox.Show("N'existe pas!");
            }
            else
            {                
                    do
                    {
                        StreamWriter fichier = new StreamWriter("C:\\Users\\Maxim P. Verreault\\Desktop\\Technique_Informatique\\Automne 2013\\Algo&Prog\\Travaux\\Notions de fichiers TEXTE\\Algorithmes\\ecrire.txt",true);
                        using (fichier)
                        {
                            sPhrase = Formulaires.DemanderValeur("Saisie phrase: ");    
                            fichier.WriteLine(sPhrase);                                 
                            fichier.Flush();
                        }
                        fichier.Close();  
                    }
                    while (sPhrase != "FIN");
                                                              
            }
