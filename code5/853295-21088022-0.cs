    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Requests;
    using System.Collections.Generic;
    using System.Net;
    
    // ...
    
    public class MyClass {
    
      // ...
    
      /// <summary>
      /// Insert new file.
      /// </summary>
      /// <param name="service">Drive API service instance.</param>
      /// <param name="title">Title of the file to insert, including the extension.</param>
      /// <param name="description">Description of the file to insert.</param>
      /// <param name="parentId">Parent folder's ID.</param>
      /// <param name="mimeType">MIME type of the file to insert.</param>
      /// <param name="filename">Filename of the file to insert.</param>
      /// <returns>Inserted file metadata, null is returned if an API error occurred.</returns>
      private static File insertFile(DriveService service, String title, String description, String parentId, String mimeType, String filename) {
        // File's metadata.
        File body = new File();
        body.Title = title;
        body.Description = description;
        body.MimeType = mimeType;
    
        // Set the parent folder.
        if (!String.IsNullOrEmpty(parentId)) {
          body.Parents = new List<ParentReference>()
              {new ParentReference() {Id = parentId}};
        }
    
        // File's content.
        byte[] byteArray = System.IO.File.ReadAllBytes(filename);
        MemoryStream stream = new MemoryStream(byteArray);
    
        try {
          FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, mimeType);
          request.Upload();
    
          File file = request.ResponseBody;
    
          // Uncomment the following line to print the File ID.
          // Console.WriteLine("File ID: " + file.Id);
    
          return file;
        } catch (Exception e) {
          Console.WriteLine("An error occurred: " + e.Message);
          return null;
        }
      }
