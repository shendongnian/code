    buton.TouchUpInside +=(s,e)=> {
        try {
            String v=Vendor[0];
            string url="my.something.com/ios_files.php?id=24&vendor="+v;
            string myParam="";
            using (WebClient client=new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType]="application/x-www-form-urlencoded";
                String Result=client.UploadString(url,myParam);
                Console.writeLine(Result);
            }
        } catch (Exception ex) {
            // do something useful, probably show an error message to the user
            Console.WriteLine (ex);
        }
    }
