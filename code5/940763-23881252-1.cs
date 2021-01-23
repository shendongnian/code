        byte[] MDT = System.Text.Encoding.ASCII.GetBytes ("1400175151406");
        byte[] CMDTEC = System.Text.Encoding.ASCII.GetBytes ("8306");
        void Envoie_Serveur(string param1)
        {
            // firstly, get CMDTEC as a string, assuming ascii encoded bytes
            string sCMDTEC = System.Text.Encoding.ASCII.GetString(CMDTEC);
            // now convert CMDTEC string to an int
            int iCMDTEC = int.Parse(sCMDTEC);
            // now do modulation etc on the int value
            iCMDTEC = iCMDTEC % 9000 + 1000;
            // now convert modulated int back into a string
            sCMDTEC = iCMDTEC.ToString();
            // now convert modulated string back to byte array, assuming ascii encoded bytes
            byte[] bCMDTEC = System.Text.Encoding.ASCII.GetBytes(sCMDTEC);
            // send the data
            this.Serveur.send(((int)this.MDT[bCMDTEC[0]]) + ((int)this.MDT[bCMDTEC[1]]) + ((int)this.MDT[bCMDTEC[2]]) + ((int)this.MDT[bCMDTEC[3]]) + int.Parse(param1));
            // convert CMDTEC bytes to string again
            sCMDTEC = System.Text.Encoding.ASCII.GetString(CMDTEC);
            
            // convert CMDTEC string to int again
            iCMDTEC = int.Parse(sCMDTEC);
            
            // increament CMDTEC
            iCMDTEC += 1;
            
            // convert back to string
            sCMDTEC = iCMDTEC.ToString();
            
            // convert back to bytes
            this.CMDTEC = System.Text.Encoding.ASCII.GetBytes(sCMDTEC);
        }
