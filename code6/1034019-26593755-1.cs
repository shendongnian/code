    var emailLine = reader.ReadLine();
    while (!emailLine.Equals("."))
    {
       // add emailLine to the email body
       emailLine = reader.readLine();
    }
    writer.WriteLine("250 OK");
    reader.Close();
    writer.Close();
    stream.Dispose();
