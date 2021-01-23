    public Stream DecryptFile(string encryptedImageFile){
      byte[] ImageBytes;
    
      ImageBytes = File.ReadAllBytes(encryptedImageFile);
    
      for (int i = 0; i < ImageBytes.Length; i++){
        ImageBytes[i] = (byte)(ImageBytes[i] ^ 5);
      }
    
      return new MemoryStream(ImageBytes);
    }
