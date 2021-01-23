    using System;
    using System.Security.Cryptography.X509Certificates;
    using ComponentPro.Net;
    
    ...
    
    public void HandleCertificateRequiredEvent()
    {
        // Create a new instance.
        Ftp client = new Ftp();
    
        client.CertificateRequired += client_CertificateRequired;
    
        // Connect to the FTP server.
        client.Connect("myserver", 21, FtpSecurityMode.Explicit);
    
        // Authenticate.
        client.Authenticate("userName", "password");
    
        // Do something here...
        client.DownloadFile("/my remote file.dat", "my local file");
    
        // Disconnect.
        client.Disconnect();
    }
    
    void client_CertificateRequired(object sender, ComponentPro.Security.CertificateRequiredEventArgs e)
    {
        // Load certificates from the local machine.
        X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        my.Open(OpenFlags.ReadOnly);
    
        // Retrieve a list of available certificates.
        X509Certificate2Collection certs = my.Certificates;
    
        // If no certificate found, return.
        if (certs.Count == 0)
        {
            e.Certificates = null;
            return;
        }
    
        // Show all certificates.
        Console.WriteLine("Select certificate:");
        for (int i = 0; i <= certs.Count; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(string.Format("{0}. [Nothing, skip this step]", i));
                continue;
            }
    
            Console.WriteLine(string.Format("{0}. {1}", i, certs[i - 1].SubjectName.Name));
        }
    
        // And ask user to choose an appropriate certificate.
        while (true)
        {
            Console.Write(string.Format("Select certificate [0 - {0}]: ", certs.Count));
    
            int certIndex;
    
            try
            {
                certIndex = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("ERROR: Wrong certificate index input!");
                continue;
            }
    
            if (certIndex > 0 && certIndex <= certs.Count)
            {
                e.Certificates = new X509Certificate2Collection(certs[certIndex]);
                return;
            }
    
            if (certIndex == 0)
                break;
    
            Console.WriteLine(string.Format("ERROR: You must enter number between 0 and {0}.", certs.Count));
        }
    }
