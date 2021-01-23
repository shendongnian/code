	var ca1 = new X509Certificate2Builder {SubjectName = "CN=Test CA1"}.Build();
	var in1A = new X509Certificate2Builder { SubjectName = "CN=Intermediate 1A", Issuer = ca1}.Build();
	var in1B = new X509Certificate2Builder { SubjectName = "CN=Intermediate 1B", Issuer = in1A}.Build();
	var cert1 = new X509Certificate2Builder { SubjectName = "CN=Test 1", Issuer = in1B, Intermediate = false }.Build();
	var cert1B = new X509Certificate2Builder { SubjectName = "CN=Test 1B", Issuer = cert1}.Build();
	var ca2 = new X509Certificate2Builder { SubjectName = "CN=Test CA2"}.Build();
	var cert2 = new X509Certificate2Builder { SubjectName = "CN=Test 2", Issuer = ca2, Intermediate = false}.Build();
	var invalidCert1 = new X509Certificate2Builder
	{
		SubjectName = "CN=Invalid 1",
		IssuerName = ca1.SubjectName.Name,
		IssuerPrivateKey = ca2.PrivateKey
	}.Build();
	var invalidCert2 = new X509Certificate2Builder
	{
		SubjectName = "CN=Invalid 2",
		Issuer = ca2,
		NotBefore = DateTime.Now.AddDays(1)
	}.Build();
