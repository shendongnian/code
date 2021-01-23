     public void ExportNewPatientsToExcel()
        {
            logger.Info("New Patients :: export to excel");
            string fileDirectory = string.Empty;
     
            if (Session[Constants.SESSION_FILE_DIRECTORY] != null)
                fileDirectory = Session[Constants.SESSION_FILE_DIRECTORY].ToString();
            else
            {
                logger.Error("New Patients::File Cache folder is not set.");
                Response.Redirect(Constants.PAGE_ERROR);
            }
     
            HttpContext context = HttpContext.Current;
     
            try
            {           
                string xsltFileName = Context.Server.MapPath(Constants.NEW_PATIENTS_XSLT_FILE_NAME);
                PatientCollection patientCollection = PatientBAO.GetNewPatients(ShowAllPatient);
     
                if (patientCollection.Count > 0 && patientCollection != null)
                {
                    string fileName = PatientBAO.GenerateNewPatientsAsExcel(fileDirectory, xsltFileName, patientCollection);
                    logger.Info("New Patients Excel version saved name :" + fileName);
                    string fileNamePart = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                    fileNamePart = fileNamePart.Substring(fileNamePart.IndexOf("_") + 1);//added to remove session id from file name
     
                    context.Items.Add(Constants.ENABLE_CACHE_SZ, Constants.ENABLE_CACHE);
                    context.Response.ClearContent();
                    context.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileNamePart);
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.TransmitFile(fileName);                
                }
                else
                {
                    ShowPopUp(Resources.Patient.RecordNotFoundToExportExcel);
                    logger.Error("New patients data not found for export to excel.");
                }
            }
            catch (Exception exc)
            {
                logger.ErrorException("Error occured while export patient details to excel.", exc);
            }
            finally
            {
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                context.Response.End();
            }
        }
