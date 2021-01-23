    internal class PBKDF2Sha256 : IDisposable
    {
        byte[] password;
        byte[] salt;
        public PBKDF2Sha256(byte[] password, byte[] salt){
            this.password=password;
            this.salt=salt;
        }
        public void Dispose(){
                Array.Clear(password,0,password.Length);
                Array.Clear(salt,0,salt.Length);
            }
        int iterationCount;
        public int IterationCount {
            get { return iterationCount; }
            set { iterationCount = value; }
        }
        public byte[] GetBytes(int dklen){
            using(var hmac=new HMACSHA256(password)){
                int hashLength=hmac.HashSize/8;
                if((hmac.HashSize&7)!=0)
                    hashLength++;
                int keyLength=dklen/hashLength;
                if((long)dklen>(0xFFFFFFFFL*hashLength) || dklen<0)
                    throw new ArgumentOutOfRangeException("dklen");
                if(dklen%hashLength!=0)
                    keyLength++;
                byte[] extendedkey=new byte[salt.Length+4];
                Buffer.BlockCopy(salt,0,extendedkey,0,salt.Length);
                using(var ms=new System.IO.MemoryStream()){
                    for(int i=0;i<keyLength;i++){
                        extendedkey[salt.Length]=(byte)(((i+1)>>24)&0xFF);
                        extendedkey[salt.Length+1]=(byte)(((i+1)>>16)&0xFF);
                        extendedkey[salt.Length+2]=(byte)(((i+1)>>8)&0xFF);
                        extendedkey[salt.Length+3]=(byte)(((i+1))&0xFF);
                        byte[] u=hmac.ComputeHash(extendedkey);
                        byte[] f=u;
                        for(int j=1;j<iterationCount;j++){
                            u=hmac.ComputeHash(u);
                            for(int k=0;k<f.Length;k++){
                                f[k]^=u[k];
                            }
                        }
                        ms.Write(f,0,f.Length);
                    }
                    byte[] dk=new byte[dklen];
                    ms.Position=0;
                    ms.Read(dk,0,dklen);
                    return dk;
                }
            }
        }
    }
