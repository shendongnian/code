    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    
    namespace UploadSvc
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                     InstanceContextMode = InstanceContextMode.PerCall,
                     IgnoreExtensionDataObject = true,
                     IncludeExceptionDetailInFaults = true)]    
          public class UploadService : IUploadService
        {
    
            public UploadedFile Upload(Stream uploading)
            {
                var upload = new UploadedFile
                {
                    FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
                };
    
                int length = 0;
                using (var writer = new FileStream(upload.FilePath, FileMode.Create))
                {
                    int readCount;
                    var buffer = new byte[8192];
                    while ((readCount = uploading.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, readCount);
                        length += readCount;
                    }
                }
    
                upload.FileLength = length;
    
                return upload;
            }
    
            public UploadedFile Upload(UploadedFile uploading, string fileName)
            {
                uploading.FileName = fileName;
                return uploading;
            }
        }
    }
