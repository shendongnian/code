         if (Request.Files["ImageFileToUpload"]!=null)
            {
                ///Saving the file to EmployeeImages folder with unique name.
                HttpPostedFileBase file = Request.Files["ImageFileToUpload"];
                fileName = UploadEmployeeImage(file);
               if(!string.isNullOrWhiteSpace(fileName))
              {
               employee.PhotoPath = fileName;
               db.Entry(employee).State = EntityState.Modified;
               await db.SaveChangesAsync();
               }
            }
            //else
            //{
             // else part not required.       
            //}
            
