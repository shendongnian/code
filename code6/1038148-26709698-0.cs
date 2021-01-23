            Cryptoki cryptoki = new Cryptoki("eTPKCS11.dll");
          
            cryptoki.Initialize();
            SlotList slots = cryptoki.Slots;
            if (slots.Count == 0)
            {
               
                return null;
            }
            Token token = null;
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].IsTokenPresent)
                    token = slots[i].Token;
            }
            // Searchs for an RSA private key object
            // Sets the template with its attributes
            CryptokiCollection template_PrivateKey = new CryptokiCollection();
            template_PrivateKey.Add(new ObjectAttribute(ObjectAttribute.CKA_CLASS, CryptokiObject.CKO_PRIVATE_KEY));
            template_PrivateKey.Add(new ObjectAttribute(ObjectAttribute.CKA_KEY_TYPE, Key.CKK_RSA));
            CryptokiCollection template_PublicKey = new CryptokiCollection();
            template_PublicKey.Add(new ObjectAttribute(ObjectAttribute.CKA_CLASS, CryptokiObject.CKO_PUBLIC_KEY));
            template_PublicKey.Add(new ObjectAttribute(ObjectAttribute.CKA_KEY_TYPE, Key.CKK_RSA));
            // Opens a read/write serial session
            Session session = token.OpenSession(Session.CKF_SERIAL_SESSION | SessionInfo.CKF_RW_SESSION);
            PIN pin = new PIN();
            pin.ShowDialog();
            // Executes the login passing the user PIN
            int nRes = session.Login(Session.CKU_USER,pin.Pin);
            if (nRes != 0)
            {
                MessageBox.Show("Wrong PIN");
                return null;
            }
            // Launchs the search specifying the template just created
            CryptokiCollection obj_PrivKey = session.Objects.Find(template_PrivateKey, 10);
            // Launchs the search specifying the template just created
            CryptokiCollection obj_PubKey = session.Objects.Find(template_PublicKey, 10);
            //CryptokiObjects o1 = session.Objects;
            RSAPrivateKey privateKey = null;
            //RSAPublicKey publicKey;
            //RSAPrivateKey tempKey=null;
            for (int i = 0; i < obj_PrivKey.Count; i++)
            {
                privateKey =(RSAPrivateKey)obj_PrivKey[i];
                if (Utilities.CompareBytes(privateKey.Modulus, modulus))
                {
                    break;
                }
            }
            
            if (privateKey == null)
            {
                MessageBox.Show(" No corresponding Private key found ");
                return null;
            }
            Cryptware.NCryptoki.Mechanism m_encrypt = Mechanism.RSA_X_509;
            byte[] aeskey = null;
            try
            {
                int re = session.DecryptInit(Mechanism.RSA_X_509, privateKey);
 
                byte[] dec = session.Decrypt(message);
               IAsymmetricBlockCipher cipher = new OaepEncoding(new RsaEngine(),new Sha256Digest(),pad);
                          Org.BouncyCastle.Math.BigInteger mod = new Org.BouncyCastle.Math.BigInteger(1,privateKey.Modulus);
                Org.BouncyCastle.Math.BigInteger exp=new Org.BouncyCastle.Math.BigInteger("1",16);
                RsaKeyParameters p_Temp = new RsaKeyParameters(false, mod, exp);
                cipher.Init(false, p_Temp);
            
               aeskey = cipher.ProcessBlock(dec, 0,dec.Length);
          
             
           }
            catch (Exception ex)
            {
                
            }
            finally
            {
                session.Logout();
           `
            }
            return aeskey;
        }
