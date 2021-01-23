    using (Stream objStream = File.OpenRead(FilePath))
    {
        // Read data from file
        byte[] arrData = { };
        // Read data from file until read position is not equals to length of file
        while (objStream.Position != objStream.Length)
        {
            // Read number of remaining bytes to read
            long lRemainingBytes = objStream.Length - objStream.Position;
            // If bytes to read greater than 2 mega bytes size create array of 2 mega bytes
            // Else create array of remaining bytes
            if (lRemainingBytes > 262144)
            {
                arrData = new byte[262144];
            }
            else
            {
                arrData = new byte[lRemainingBytes];
            }
            // Read data from file
            objStream.Read(arrData, 0, arrData.Length);
            // Other code whatever you want to deal with read data
       }
    }
