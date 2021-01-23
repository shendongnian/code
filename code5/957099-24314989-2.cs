        public object NewFromEntity(Entity ent)
            {    
                using (ResultBuffer resBuf = ent.GetXDataForApplication("Member"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
    
                    bf.Binder = new MyBinder();
    
                    MemoryStream ms = this.ResBufToStream(resBuf);
                    return bf.Deserialize(ms);
                }    
            }
