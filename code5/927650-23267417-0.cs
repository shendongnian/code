    string x = "";
    for (int i = 0; i < clients.Count; i++) {
         if (!String.IsNullOrEmpty(clients[i].Name)) {
              x += clients[i].Name.ToString();
         }
    }
