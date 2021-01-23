		unsigned char* templateBuf = (unsigned char*)malloc( userHeader.numOfFinger * 2 * BS_TEMPLATE_SIZE );
		int bufPos = 0;
		for( int i = 0; i < userHeader.numOfFinger * 2; i++ )
		{
			result = BS_ScanTemplate( handle, templateBuf + bufPos );
			bufPos += BS_TEMPLATE_SIZE;
		}
    This code calls `BS_ScanTemplate` multiple times and stores the results sequentially in a byte array.  Your code does the following:
            byte[] templateBuf = new byte[userHdr.numOfFinger * 2 * BS_TEMPLATE_SIZE];
            int bufPos = 0;
            for (int i = 0; i < userHdr.numOfFinger * 2; i++)
            {
                templateBuf = new byte[userHdr.numOfFinger * 2 * BS_TEMPLATE_SIZE * bufPos];
                result = BSSDK.BS_ScanTemplate(m_Handle, templateBuf);
                bufPos += BS_TEMPLATE_SIZE;
            }
    Rather than storing the results of `BS_ScanTemplate` sequentially, this code throws away the results from each preceding call by reallocating the array.  Perhaps you want something like:
            byte[] templateBuf = new byte[userHdr.numOfFinger * 2 * BS_TEMPLATE_SIZE];
            for (int i = 0, bufPos = 0; i < userHdr.numOfFinger * 2; i++)
            {
                byte[] singleBuf = new byte[BS_TEMPLATE_SIZE];
                result = BSSDK.BS_ScanTemplate(m_Handle, singleBuf);
                Array.Copy(singleBuf, 0, templateBuf, bufPos, singleBuf.Length);
                bufPos += singleBuf.Length;
            }
