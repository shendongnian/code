        private DesignerVerbCollection _verbs;
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_verbs == null)
                {
                    _verbs = new DesignerVerbCollection();
                    _verbs.Add(new DesignerVerb("Create Title", new EventHandler(MyCreateTitleHandler)));
                }
                return _verbs;
            }
        }
        private void MyCreateTitleHandler(object sender, EventArgs e)
        {
            // Do here something but take care to show things via IUIService service
            IUIService uiService = GetService(typeof(IUIService)) as IUIService;
        }
