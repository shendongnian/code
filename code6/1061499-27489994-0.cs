    var targetAssemblies = new[] { typeof(Activity).Assembly };
    var knownActivities = new Dictionary<Guid, Type>();
    var baseType = typeof(Activity);
    var sha1 = new SHA1CryptoServiceProvider();
    foreach (var t in targetAssemblies.SelectMany(a => a.GetTypes()))
    {
        if (t.IsPublic && !t.IsAbstract && baseType.IsAssignableFrom(t))
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(t.AssemblyQualifiedName));
            // hash is 20 bytes long, we are truncating it to 16 to fit the guid
            var guidData = new byte[16];
            Buffer.BlockCopy(hash, 0, guidData, 0, 16);
            var typeGuid = new Guid(hash.Take(16).ToArray());
            if (knownActivities.ContainsKey(typeGuid))
            {
                throw new InvalidOperationException("Collision");
            }
            knownActivities.Add(typeGuid, t);
        }
    }
