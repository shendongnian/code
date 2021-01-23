    using (var br = new BinaryReader(stream)) {
        br.BaseStream.Seek(0x32500, SeekOrigin.Begin);
        var bytes = br.ReadBytes(0x3256F - 0x32500);
        if (bytes.All(x => x == 0)) {
            label.Text = "No";
        }
    }
