        Dictionary<string, string> audience = new Dictionary<string, string>();
        audience.Add("alias", string.Join(", ", messages.UserIds));
        Dictionary<string, string> notification = new Dictionary<string, string>();
        notification.Add("alert", messages.Message);
        Dictionary<string, string> pushNotice = new Dictionary<string, string>();
        pushNotice.Add("audience", new JavaScriptSerializer().Serialize(audience));
        pushNotice.Add("notification", new JavaScriptSerializer().Serialize(notification));
