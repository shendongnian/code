    using (var stream = assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().Single(n => n.EndsWith("Scripts.config")))) {
        using (var sr = new StreamReader(stream)) {
            var content = sr.ReadToEnd();
            ...
        }
    }
