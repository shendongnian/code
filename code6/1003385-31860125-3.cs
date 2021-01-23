    [CustomAction]
        public static ActionResult DeployDacpac(Session session)
        {
            try
            {
                string sql = string.Format("SELECT Data FROM Binary WHERE Name = 'Database.dacpac'");
                View view = session.Database.OpenView(sql);
                view.Execute();
                var dataStream = view.First()["Data"] as Stream;
                byte[] buffer = new byte[dataStream.Length];
                int bytesRead;
                while ((bytesRead = dataStream.Read(buffer, 0, buffer.Length)) > 0) ;
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    var dacOptions = new DacDeployOptions();
                    dacOptions.BlockOnPossibleDataLoss = false;
                    dacOptions.DropDmlTriggersNotInSource = false;
                    dacOptions.DropObjectsNotInSource = false;
                    var dacServiceInstance = new DacServices(GenerateConnectionString(session["SQLSERVER"], session["SQLDATABASE"], session["SQLUSER"], session["SQLPASSWORD"]));
                    using (DacPackage dacpac = DacPackage.Load(ms))
                    {
                        dacServiceInstance.Deploy(dacpac, session["SQLDATABASE"], upgradeExisting: true, options: dacOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                session.Log(ex.Message);
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }
