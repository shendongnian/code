            System.Type objNotesType = System.Type.GetTypeFromProgID("Notes.NotesSession");
            dynamic ns = System.Activator.CreateInstance(objNotesType);
            dynamic nd = ns.GetDatabase(AppSettings.NotesServer, AppSettings.NotesReplicaID);
            if (nd.IsOpen != true) nd.OpenByReplicaID(nd.Server, AppSettings.NotesReplicaID);
            dynamic nv = nd.GetView(AppSettings.NotesView);
