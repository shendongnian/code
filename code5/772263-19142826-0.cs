                                if (cert.SignatureAlgorithm.FriendlyName.ToString().Contains("sha256"))
                            {
                                SHA256Managed sha256 = new SHA256Managed();
                                byte[] hash256 = sha256.ComputeHash(sig);
                                RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
                                verify_all.Add(csp.VerifyHash(hash256, CryptoConfig.MapNameToOID("SHA256"), vData));
                            }
                            else if (cert.SignatureAlgorithm.FriendlyName.ToString().Contains("sha1"))
                            {
                                SHA1Managed Sha1 = new SHA1Managed();
                                byte[] hash1 = sha1.ComputeHash(sig);                                
                                RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
                                verify_all.Add(csp.VerifyHash(hash1, CryptoConfig.MapNameToOID("SHA256"), vData));
                            }
