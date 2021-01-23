		for( int i = 0; i < userHeader.numOfFinger * 2; i++ )
		{
			if( i % 2 == 0 )
			{
				userHeader.fingerChecksum[i/2] = 0;
			}
			unsigned char* templateData = templateBuf + i * BS_TEMPLATE_SIZE;
			for( int j = 0; j < BS_TEMPLATE_SIZE; j++ )
			{
				userHeader.fingerChecksum[i/2] += templateData[j];
			}
		}
    The c# code does:
            for (int i = 0; i < userHdr.numOfFinger * 2; i++)
            {
                if (i % 2 == 0)
                {
                    userHdr.checksum[i / 2] = 0;
                }
                byte[] templateData = templateBuf;
                for (int j = 0; j < 2000 - 1; j++)
                {
                    userHdr.checksum[i / 2] += templateData[j];
                }
            }
    As you can see the c++ code loops twice as many times as the c# code.  The c# code probably should be:
            for (int i = 0; i < userHdr.numOfFinger; i++)
            {
                if (i % 2 == 0)
                {
                    userHdr.checksum[i / 2] = 0;
                }
                for (int j = 0; j < BS_TEMPLATE_SIZE; j++)
                {
                    userHdr.checksum[i / 2] += templateBuf[i * BS_TEMPLATE_SIZE + j];
                }
            }
