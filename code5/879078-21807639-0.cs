                byte[] purchaseInfoBytes = Encoding.UTF8.GetBytes(purchaseInfo);
                byte[] signatureBytes = Convert.FromBase64String(signature);
                byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
                result = CryptUtil.VerifySignature_2048_Bit_PKCS1_v1_5(
                    purchaseInfoBytes,
                    signatureBytes,
                    publicKeyBytes);
