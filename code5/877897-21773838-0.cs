            IAsyncResult result =Microsoft.Xna.Framework.GamerServices.Guide.BeginShowMessageBox(
    "Info",
    "Alarm has been raised",
    new string[] { "OK", "Call emergency" },
    0,
    Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.None,
    null,
    null);
    
           result.AsyncWaitHandle.WaitOne();
            media.AutoPlay = true;
        }
