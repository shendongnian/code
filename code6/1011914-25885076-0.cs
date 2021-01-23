    CDO.Message msg = new CDO.Message();
    // load MIME into CDO
    using (FileStream stream = new FileStream(emailFileSpec, FileMode.Open))
    {
        // read file into a byte stream
        byte[] emailData = new byte[stream.Length];
        stream.Read(emailData, 0, (int)stream.Length);
        // load byte stream data into an ADODB stream for CDO
        ADODB.Stream stm = new ADODB.Stream();
        stm.Open(
            System.Reflection.Missing.Value,
            ADODB.ConnectModeEnum.adModeUnknown,
            ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified,
            null, null);
        stm.Type = ADODB.StreamTypeEnum.adTypeBinary;
        stm.Write(emailData);
        stm.Flush();
        stm.SetEOS();
        // attach data source to the CDO object
        msg.DataSource.OpenObject(stm, "_Stream");
        stm.Close();
    }
