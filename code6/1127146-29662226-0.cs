     public void writeCachedImageData(Int16[,] atoms, int cameraID, int runID, int seqID)
        {
            byte[] bytesAtoms = new byte[2 * 1000 * 1000];
           
            Buffer.BlockCopy(atoms, 0, bytesAtoms, 0, bytesAtoms.Length);
            Clipboard.SetData(DataFormats.Serializable, bytesAtoms);
            Clipboard.SetData(DataFormats.Serializable, bytesAtoms);
            Clipboard.SetData(DataFormats.Serializable, bytesAtoms);
         
        }
