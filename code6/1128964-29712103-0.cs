    public List<Message> AllMessages
            {
                get
                {
                    _AllMessages = Session["AllMessages"] as List<Message>;
                    if (_AllMessages==null)
                    {
                        Session["AllMessages"] = LoadMessages();
                        _AllMessages = Session["AllMessages"];
                    }
                    return _AllMessages;
                }
                set
                {
                    Session["AllMessages"] = value;
                }
            }
