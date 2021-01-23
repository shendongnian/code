     private static string basename;
     public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
            {
                if (runKind == WizardRunKind.AsMultiProject)
                {
                    basename = replacementsDictionary["$specifiedsolutionname$"];
                }
                else
                {
                    replacementsDictionary["$safeprojectname$"] = basename;
                }
            }
