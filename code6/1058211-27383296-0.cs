    // using System.Runtime.InteropServices.WindowsRuntime;
    byte[] foo = new byte[] { 20, 21, 22, 23 };
    IHttpContent content = new HttpBufferContent(foo.AsBuffer());
    // using Windows.Storage.Streams;
    IBuffer barBuffer = await content.ReadAsBufferAsync();
    byte[] bararray = barBuffer.ToArray();
