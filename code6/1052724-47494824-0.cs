                var mergetool = new ThirdPartyToolDefinition(".*",ToolOperations.Merge,"vsDiffMerge.exe","","/m %1 %2 %3 %4");
                var toolcol= ThirdPartyToolDefinitionCollection.Instance.FindTool(".*",ToolOperations.Merge);
                if (toolcol == null)
                {
                    ThirdPartyToolDefinitionCollection.Instance.AddTool(mergetool);
                    ThirdPartyToolDefinitionCollection.Instance.PersistAllToRegistry();
                }
