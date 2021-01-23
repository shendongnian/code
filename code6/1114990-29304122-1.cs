    using (var zipStream = new ZipOutputStream(outputMemStream))
    {
        zipStream.IsStreamOwner = false;
        // Set compression level
        zipStream.SetLevel(3); 
        foreach (var documentIdString in documentUniqueIdentifiers)
        {   
            ...
            var blockBlob = container.GetBlockBlobReference(documentId.ToString());
            using (var fileMemoryStream = new MemoryStream())
            {
                // Populate stream with bytes
                blockBlob.DownloadToStream(fileMemoryStream);
                // Reset position of stream
                fileMemoryStream.Position = 0;
                // Create zip entry and set date
                ZipEntry newEntry = new ZipEntry(document.FileName);
                newEntry.DateTime = DateTime.Now;
                // Put entry RECORD, not actual data
                zipStream.PutNextEntry(newEntry);
                // Copy date to zip RECORD
                StreamUtils.Copy(fileMemoryStream, zipStream, new byte[4096]);
                // Mark this RECORD closed in the zip
                zipStream.CloseEntry();
            }
        }
        // Close the zip stream, parent stays open due to !IsStreamOwner
        zipStream.Close();
        outputMemStream.Seek(0, SeekOrigin.Begin);
        return outputMemStream;
    }
