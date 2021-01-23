    string[] lines = System.IO.File.ReadAllLines("local.db");
    var binWriter = new   System.IO.BinaryWriter(System.IO.File.OpenWrite("l2.db"));
    foreach (string line1 in lines)
    {
        // Write line with UNIX-style end-of-line character
        sslStream.Write(Encoding.ASCII.GetBytes(line1.ToString() + "\n"));
    }
    sslStream.Write(Encoding.ASCII.GetBytes("EOF"));
