    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Org.BouncyCastle;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto.Signers;
    using Org.BouncyCastle.Crypto.Digests;
    using System.Windows.Forms;
    
    namespace FooTest
    {
        class FooImplementing
        {
            private RsaBlindingEngine rsaBlindingEngine = new RsaBlindingEngine();
            private RsaBlindingFactorGenerator blindingFactorGenerator = new RsaBlindingFactorGenerator();
            private RsaBlindingParameters blindingParameteres;
            private RsaKeyPairGenerator aliceRsaKeyGenerator = new RsaKeyPairGenerator();
            private AsymmetricCipherKeyPair aliceKeyPair;
            private RsaKeyPairGenerator bobRsaKeyGenerator = new RsaKeyPairGenerator();
            private AsymmetricCipherKeyPair bobKeyPair;
            private byte[] inputMessage;
            public FooImplementing(string message)
            {
                inputMessage = getBytes(message);
                aliceRsaKeyGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 1024));
                aliceKeyPair = aliceRsaKeyGenerator.GenerateKeyPair();
                //******************************************************************************
                bobRsaKeyGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 1024));
                bobKeyPair = bobRsaKeyGenerator.GenerateKeyPair();
                //******************************************************************************
                blindingFactorGenerator.Init(bobKeyPair.Public);
                blindingParameteres = new RsaBlindingParameters((RsaKeyParameters)bobKeyPair.Public, blindingFactorGenerator.GenerateBlindingFactor());
            }
    
            public byte[] getBytes(string input)
            {
                byte[] bytes = new byte[input.Length * sizeof(char)];
                System.Buffer.BlockCopy(input.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
    
            public string GetString(byte[] bytes)
            {
                char[] chars = new char[bytes.Length / sizeof(char)];
                System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                return new string(chars);
            }
    
            public byte[] blindTheMessage(TextBox t1)
            {
                for (int i = 0; i < inputMessage.Length; i++)
                {
                    t1.Text += inputMessage[i].ToString();
                }
                PssSigner messageBlinder = new PssSigner(rsaBlindingEngine, new Sha1Digest(), 15);
                messageBlinder.Init(true, blindingParameteres);
                messageBlinder.BlockUpdate(inputMessage, 0, inputMessage.Length);
                byte[] blindedMessage = messageBlinder.GenerateSignature();
                return blindedMessage;
            }
    
            public byte[] blindSignature(byte[] input)
            {
                RsaEngine rsaEngine = new RsaEngine();
                rsaEngine.Init(true, bobKeyPair.Private);
                byte[] blindSignedMessage = rsaEngine.ProcessBlock(input, 0, input.Length);
                return blindSignedMessage;
            }
    
            public byte[] unblindeTheSignedData(byte[] input)
            {
                rsaBlindingEngine.Init(false, blindingParameteres);
                byte[] messageForSending = rsaBlindingEngine.ProcessBlock(input, 0, input.Length);
                return messageForSending;
            }
    
            public bool verifyBlindSignature(byte[] input, TextBox t1)
            {            
                PssSigner verifier = new PssSigner(new RsaEngine(), new Sha1Digest(), 15);
                verifier.Init(false, bobKeyPair.Public);
                verifier.BlockUpdate(inputMessage, 0, inputMessage.Length);
                for (int i = 0; i < inputMessage.Length; i++)
                {
                    t1.Text += inputMessage[i].ToString();
                }
                return verifier.VerifySignature(input);
            }
    
            public byte[] signedWithRsa(byte[] input)
            {
                ISigner signer = SignerUtilities.GetSigner("SHA1withRSA");
                signer.Init(true, aliceKeyPair.Private);
                signer.BlockUpdate(input, 0, input.Length);
                byte[] signedData = signer.GenerateSignature();
                return signedData;
            }
    
            public bool verifyRsaSignedData(byte[] input, byte[] signature)
            {
                ISigner verifier = SignerUtilities.GetSigner("SHA1withRSA");
                verifier.Init(false, aliceKeyPair.Public);
                verifier.BlockUpdate(input, 0, input.Length);
                return verifier.VerifySignature(signature);
            }
    
        }
    }
