    var results = pipeline.Invoke();
    foreach (PSObject result in results) {
    Console.WriteLine(result.Properties["DisplayName"].Value);
    Console.WriteLine(result.Properties["PrimarySmtpAddress"].Value);
    Console.WriteLine(result.Properties["ForwardingAddress"].Value);
    Console.WriteLine(result.Properties["alias"].Value);
    Console.WriteLine(result.Properties["identity"].Value);
    Console.WriteLine(result.Properties["legacyexchangeDN "].Value);
    }
