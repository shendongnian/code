           SwaggerSpecConfig.Customize(c =>
            {
                // single XML Comment Files
                //c.IncludeXmlComments(GetXmlCommentsPath());
                // Multiple XML Comment Files
                string[] paths = GetXmlCommentsPaths();
                foreach (string xmlCommentsPath in paths)
                {
                    c.OperationFilter(new ApplyActionXmlComments(xmlCommentsPath))
                        .ModelFilter(new ApplyTypeXmlComments(xmlCommentsPath));
                }
            });
