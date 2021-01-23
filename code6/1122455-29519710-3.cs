    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Deployment.WindowsInstaller;
    namespace DGCustomActions
    {
        public class CustomActions
        {
            [CustomAction]
            public static ActionResult SearchAndReplace(Session session)
            {
                session.Log("Begin SearchAndReplace");
                string InputString = session["InputString"];
                string SearchString = session["SearchString"];
                string ReplaceString = session["ReplaceString"];
                session["OutputString"] = InputString.Replace(SearchString, ReplaceString);
                session.Log("SearchAndReplace Successful");
                return ActionResult.Success;
            }
        }
    }
