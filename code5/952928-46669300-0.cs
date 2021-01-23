        /// <summary>
        /// Check for Authenticode Signature
        /// </summary>
        /// <param name="providedFilePath"></param>
        /// <returns></returns>
        private bool VerifyAuthenticodeSignature(string providedFilePath)
        {
            bool isSigned = true;
            string fileName = Path.GetFileName(providedFilePath);
            string calculatedFullPath = Path.GetFullPath(providedFilePath);
            
            if (File.Exists(calculatedFullPath))
            {
                Log.LogMessage(string.Format("Verifying file '{0}'", calculatedFullPath));
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddCommand("Get-AuthenticodeSignature", true);
                    ps.AddParameter("FilePath", calculatedFullPath);
                    var cmdLetResults = ps.Invoke();
                    foreach (PSObject result in cmdLetResults)
                    {
                        Signature s = (Signature)result.BaseObject;
                        isSigned = s.Status.Equals(SignatureStatus.Valid);
                        if (isSigned == false)
                        {
                            ErrorList.Add(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));
                        }
                        else
                        {
                            Log.LogMessage(string.Format("!!!AuthenticodeSignature status is '{0}' for file '{1}' !!!", s.Status.ToString(), calculatedFullPath));
                        }
                        break;
                    }
                }
            }
            else
            {
                ErrorList.Add(string.Format("File '{0}' does not exist. Unable to verify AuthenticodeSignature", calculatedFullPath));
                isSigned = false;
            }
            return isSigned;
        }
