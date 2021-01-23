     string ScriptfullPath = Application.StartupPath.ToString()+"\\jquery\\script.js";;
            string htmlContent;
            using (StreamReader reader = new StreamReader(Application.StartupPath +  \\JQuery\\sample.htm"))
            {
                htmlContent = reader.ReadToEnd();
            }
            htmlContent = htmlContent.Replace("{Fullpath}", ScriptfullPath);
