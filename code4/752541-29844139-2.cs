    string strText = "SomeTestData";
    
                //CONVERT STRING TO BYTE ARRAY
                byte[] bytedata = ConvertStringToByte(strText);                              
    
                //VICE VERSA ** Byte[] To Text **
                if (bytedata  != null)
                {                    
                    //BYTE ARRAY TO STRING
                    string strPdfText = ConvertByteArrayToString(result);
                }
    
    
    //Method to Convert Byte[] to string
    private static string ConvertByteArrayToString(Byte[] ByteOutput)
    {
                string StringOutput = System.Text.Encoding.UTF8.GetString(ByteOutput);
                return StringOutput;
    }
    
    
    //Method to Convert String to Byte[]
    public static byte[] ConvertStringToByte(string Input)
    {
                return System.Text.Encoding.UTF8.GetBytes(Input);
    }
