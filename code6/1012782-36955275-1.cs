    private static string GetMessageHeaderForWelcome(string email, string callBackUrl)
        {
            var header = new Header();
            //header.AddSubstitution("{{FirstName}}", new List<string> { "Dilip" });
            //header.AddSubstitution("{{LastName}}", new List<string> { "Nikam" });
            header.AddSubstitution("{{EmailID}}", new List<string> { email });
            header.AddSubstitution("-VERIFICATIONURL-", new List<string>() { callBackUrl });
            //header.AddSubstitution("*|VERIFICATIONURL|*", new List<string> { callBackUrl });
            //header.AddSubstitution("{{VERIFICATIONURL}}", new List<string> { callBackUrl });
            header.AddFilterSetting("templates", new List<string> { "enabled" }, "1");
            header.AddFilterSetting("templates", new List<string> { "template_id" }, WelcomeSendGridTemplateID);
            return header.JsonString();
        }
