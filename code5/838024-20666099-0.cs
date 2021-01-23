        string xpto = "{ 0, 0, 5 },{  1, 255, 1 }";
        List<byte[]> listOfByteArrs = new List<byte[]>();
        string[] byteArrSplitter = Regex.Split(xpto, "},{");
        foreach (string byteArrString in byteArrSplitter)
        {
            string[] byteSplitter = Regex.Split(byteArrString, ",");
            byte[] byteHolder = new byte[byteSplitter.Count()];
            for (int i = 0; i < byteSplitter.Count(); i++)
            {
                byteHolder[i] = Convert.ToByte(Regex.Replace(byteSplitter[i].ToString(), @"\{|\}|\s", ""));
            }
            listOfByteArrs.Add(byteHolder);
        }
