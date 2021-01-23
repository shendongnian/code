    var file = File.ReadAllBytes(txtFile.Text);
    using (var hash = new SHA256Managed())
    {
       byte[] digest = hash.ComputeHash(file);
       txtHash.Text = BitConverter.ToString(digest).Replace("-", String.Empty);
    }
