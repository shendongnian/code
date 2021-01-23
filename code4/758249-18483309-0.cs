            MacroMethod method = new MacroMethod("MyEditedDoc", parameters => CMSContext.EditedDocument)
            {
                Type = typeof(TreeNode),
                Comment = "Returns currently edited document.",
                MinimumParameters = 0
            };
            MacroMethods.RegisterMethod(method);
