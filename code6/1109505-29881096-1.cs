        [PluginController("Utilities")]
        [Umbraco.Web.Trees.Tree("Utilities", "KeyphraseTree", "Keyphrase", iconClosed: "icon-doc", sortOrder: 1)]
        public class KeyphraseTreeController : TreeController
        {
            private KeyphraseApiController _keyphraseApiController;
            public KeyphraseTreeController()
            {
                 _keyphraseApiController = new KeyphraseApiController();
            }
            protected override TreeNodeCollection GetTreeNodes(string id,                                                                FormDataCollection queryStrings)
            {
                var nodes = new TreeNodeCollection();
                var keyphrases = _keyphraseApiController.GetAll();
                if (id == Constants.System.Root.ToInvariantString())
                {
                    foreach (var keyphrase in keyphrases)
                    {
                        var node = CreateTreeNode(
                        keyphrase.Id.ToString(),
                        "-1",
                        queryStrings,
                        keyphrase.ToString(),
                        "icon-book-alt",
                        false);
                        nodes.Add(node);
                    }
                }
                return nodes;
            }
            protected override MenuItemCollection GetMenuForNode(string id,                                                               FormDataCollection queryStrings)
            {
                var menu = new MenuItemCollection();
                if (id == Constants.System.Root.ToInvariantString())
                {
                    // root actions
                     menu.Items.Add<CreateChildEntity, ActionNew>(ui.Text("actions", ActionNew.Instance.Alias));
                    menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias), true);
                    return menu;
                }
                else
                {
                    menu.Items.Add<ActionDelete>(ui.Text("actions", ActionDelete.Instance.Alias));
                }
                return menu;
            }
        }
