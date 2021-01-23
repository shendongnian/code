    private string EncodePassword(string pass, int passwordFormat, string salt)
    {
    	byte[] numArray;
    	byte[] numArray1;
    	string base64String;
    	bool length = passwordFormat != 0;
    	if (length)
    	{
    		byte[] bytes = Encoding.Unicode.GetBytes(pass);
    		byte[] numArray2 = Convert.FromBase64String(salt);
    		byte[] numArray3 = null;
    		length = passwordFormat != 1;
    		if (length)
    		{
    			numArray1 = new byte[(int)numArray2.Length + (int)bytes.Length];
    			Buffer.BlockCopy(numArray2, 0, numArray1, 0, (int)numArray2.Length);
    			Buffer.BlockCopy(bytes, 0, numArray1, (int)numArray2.Length, (int)bytes.Length);
    			numArray3 = this.EncryptPassword(numArray1);
    		}
    		else
    		{
    			HashAlgorithm hashAlgorithm = this.GetHashAlgorithm();
    			length = hashAlgorithm as KeyedHashAlgorithm <= null;
    			if (length)
    			{
    				numArray1 = new byte[(int)numArray2.Length + (int)bytes.Length];
    				Buffer.BlockCopy(numArray2, 0, numArray1, 0, (int)numArray2.Length);
    				Buffer.BlockCopy(bytes, 0, numArray1, (int)numArray2.Length, (int)bytes.Length);
    				numArray3 = hashAlgorithm.ComputeHash(numArray1);
    			}
    			else
    			{
    				KeyedHashAlgorithm keyedHashAlgorithm = (KeyedHashAlgorithm)hashAlgorithm;
    				length = (int)keyedHashAlgorithm.Key.Length != (int)numArray2.Length;
    				if (length)
    				{
    					length = (int)keyedHashAlgorithm.Key.Length >= (int)numArray2.Length;
    					if (length)
    					{
    						numArray = new byte[(int)keyedHashAlgorithm.Key.Length];
    						int num = 0;
    						while (true)
    						{
    							length = num < (int)numArray.Length;
    							if (!length)
    							{
    								break;
    							}
    							int num1 = Math.Min((int)numArray2.Length, (int)numArray.Length - num);
    							Buffer.BlockCopy(numArray2, 0, numArray, num, num1);
    							num = num + num1;
    						}
    						keyedHashAlgorithm.Key = numArray;
    					}
    					else
    					{
    						numArray = new byte[(int)keyedHashAlgorithm.Key.Length];
    						Buffer.BlockCopy(numArray2, 0, numArray, 0, (int)numArray.Length);
    						keyedHashAlgorithm.Key = numArray;
    					}
    				}
    				else
    				{
    					keyedHashAlgorithm.Key = numArray2;
    				}
    				numArray3 = keyedHashAlgorithm.ComputeHash(bytes);
    			}
    		}
    		base64String = Convert.ToBase64String(numArray3);
    	}
    	else
    	{
    		base64String = pass;
    	}
    	return base64String;
    }
