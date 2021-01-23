    partial void Overzicht_project_telling_Created()
        {
            DataWorkspace dataWorkspace = new DataWorkspace();
            var operation = dataWorkspace.ApplicationData.StoredProcedureDefinitions.AddNew();
            //operation.Database = "dbMSccData";
            operation.Procedure = "dbo.Overzicht_Project_telling_s001";
            dataWorkspace.ApplicationData.SaveChanges();
            this.Refresh();
        }
