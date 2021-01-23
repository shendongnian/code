        private void btngetUserInfo_Click(object sender, EventArgs e)
        {
            int result;
            BSSDK.BSUserHdrEx userHdr = BSSDK.BSUserHdrEx.CreateDefaultBSUserHdrEx();
            userHdr.ID = 2; // 0 cannot be assigned as a user ID
            userHdr.startDateTime = 0; // no check for start date
            userHdr.expireDateTime = 0; // no check for expiry date
            userHdr.adminLevel = BSSDK.BS_USER_NORMAL;
            userHdr.securityLevel = BSSDK.BS_USER_SECURITY_DEFAULT;
            userHdr.authMode = BSSDK.BS_AUTH_MODE_DISABLED; // use the authentication mode of the device
            userHdr.accessGroupMask = 0xffff0201; // a member of Group 1 and Group 2;
            Encoding.UTF8.GetBytes("Madman").CopyTo(userHdr.name, 0);
            Encoding.UTF8.GetBytes("INC").CopyTo(userHdr.department, 0);
            Encoding.UTF8.GetBytes("").CopyTo(userHdr.password, 0);
            userHdr.password = Encoding.UTF8.GetBytes("");  // no password is enrolled. Password should be longer than 4 bytes.
            userHdr.numOfFinger = 2;
            byte[] templateBuf = new byte[userHdr.numOfFinger * 2 * BSSDK.BS_TEMPLATE_SIZE];
            for (int i = 0, bufPos = 0; i < userHdr.numOfFinger * 2; i++)
            {
                byte[] singleBuf = new byte[BSSDK.BS_TEMPLATE_SIZE];
                result = BSSDK.BS_ScanTemplate(m_Handle, singleBuf);
                Array.Copy(singleBuf, 0, templateBuf, bufPos, singleBuf.Length);
                bufPos += singleBuf.Length;
            }
            userHdr.duressMask = 0; // no duress finger
            for (int i = 0; i < userHdr.numOfFinger * 2; i++)
            {
                if (i % 2 == 0)
                {
                    userHdr.checksum[i / 2] = 0;
                }
                // byte[] templateData = templateBuf;
                for (int j = 0; j < BSSDK.BS_TEMPLATE_SIZE; j++)
                {
                    userHdr.checksum[i / 2] += templateBuf[i * BSSDK.BS_TEMPLATE_SIZE + j];
                }
            }
            // enroll the user
            result = BSSDK.BS_EnrollUserBioStation2(m_Handle, ref userHdr, templateBuf);
            if (result == (int)BSSDK.BS_RET_CODE.BS_SUCCESS)
            {
                MessageBox.Show("user " + userHdr.name.ToString() + " enrolled");
            }
    
