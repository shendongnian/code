            int start = rptxml.IndexOf("<TableColumns>");
            int end = rptxml.IndexOf("</TableColumns>") + "</TableColumns>".Length;
            String resizedcolumns = String.format(
                "<TableColumns>"
                + "<TableColumn><Width>{0}in</Width></TableColumn>"
                + "<TableColumn><Width>{1}in</Width></TableColumn>"
                + "<TableColumn><Width>{2}in</Width></TableColumn>"
                + "<TableColumn><Width>{3}in</Width></TableColumn>"
                + "<TableColumn><Width>{4}in</Width></TableColumn>"
                + "<TableColumn><Width>{5}in</Width></TableColumn>"
                + "</TableColumns>"
                , resizedwidth[0], resizedwidth[1], resizedwidth[2], resizedwidth[3], resizedwidth[4], resizedwidth[5]
                );
            rptxml = rptxml.Substring(0, start) + resizedcolumns + rptxml.Substring(end);
