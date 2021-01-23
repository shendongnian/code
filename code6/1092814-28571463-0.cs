    public static void SendCommandSynchronously(this Document doc,string command)
        {
            var acadDoc = doc.AcadDocument;
            acadDoc.GetType().InvokeMember(
                "SendCommand",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                acadDoc,
                new[] { command + "\n" });
        }
