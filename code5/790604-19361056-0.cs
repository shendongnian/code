        string file = "XMLFile1.xml";
        string text = File.ReadAllText(file);
        text = text.Replace("<DataProvider DataConnection=\"Database1Connection\" SupportSql=\"true\" />",
            "<DataProvider DataConnection=\"Database1Connection\" SupportSql=\"true\">" +
            "<Selection>" +
             "<Table Name=\"Query2\">" +
             "<Columns>" +
             " <Column Name=\"PName\" />" +
              "<Column Name=\"Prog\" />" +
              "<Column Name=\"RDate\" />" +
             "</Columns>" +
             "</Table>" +
             "</Selection>" +
            "</DataProvider> ");
        File.WriteAllText(file, text);
