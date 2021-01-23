        emailAdres = textEmail.Text; password= textPassw.Text;
        xmppCC = (XmppClientConnection)Application["xmpp"];
        Jid jidSender = new Jid(emailAdres);
        if (xmppCC == null)
        {
            xmppCC = new XmppClientConnection(jidSender.Server);
            Application["xmpp"] = xmppCC;
        }
        
        xmppCC.Username = jidSender.User;
        // xmppCC.Server = jidSender.Server; it will be resolved with AutoResolveConnectServer = true
        xmppCC.Password = password;
        xmppCC.AutoResolveConnectServer = true;
