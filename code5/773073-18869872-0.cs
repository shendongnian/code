    lock(Path + file.Name) {
        System.IO.Directory.CreateDirectory(Path);
        System.IO.FileStream stream = System.IO.File.Create(Path + file.Name);
        stream.Write(document, 0, document.Length);
        stream.Close();
    }
