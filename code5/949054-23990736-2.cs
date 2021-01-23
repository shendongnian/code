   			ContentInfo contentInfo = new ContentInfo(new System.Text.UTF8Encoding().GetBytes(cArray));
			SignedCms cms = new SignedCms (contentInfo);
			CmsSigner signer = new CmsSigner (cert);
			cms.ComputeSignature (signer);
			byte[] pkcs7=cms.Encode ();
			File.WriteAllBytes(@"../../Foo.p7b", pkcs7);
