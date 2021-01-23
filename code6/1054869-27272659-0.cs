    public static byte[] GetResourceAsByteArray(string filename)
        {
            var assembly = Assembly.GetCallingAssembly();
            using (var resFilestream = assembly.GetManifestResourceStream(filename))
            {
                if (resFilestream == null) return null;
                var ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }
