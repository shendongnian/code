    internal sealed class PageInitializer {
        private HashSet<Control> alreadyInitializedControls = new HashSet<Control>();
        private Page page;
        internal PageInitializer(Page page) {
            this.page = page;
        }
        internal static void HookEventsForUserControlInitialization(Page page) {
            var initializer = new PageInitializer(page);
            page.PreInit += initializer.PreInit;
            page.PreLoad += initializer.PreLoad;
        }
        private void PreInit(object sender, EventArgs e) {
            this.RecursivelyInitializeMasterPages();
        }
        private void RecursivelyInitializeMasterPages() {
            foreach (var masterPage in this.GetMasterPages())
                this.InitializeUserControl(masterPage);
        }
        private IEnumerable<MasterPage> GetMasterPages() {
            MasterPage master = this.page.Master;
            while (master != null) {
                yield return master;
                master = master.Master;
            }
        }
        private void PreLoad(object sender, EventArgs e) {
            this.InitializeControlHierarchy(this.page);
        }
        private void InitializeControlHierarchy(Control control) {
            var dataBoundControl = control as DataBoundControl;
            if (dataBoundControl != null) {
                dataBoundControl.DataBound += this.InitializeDataBoundControl;
            } else {
                var userControl = control as UserControl;
                if (userControl != null)
                    this.InitializeUserControl(userControl);
                foreach (var childControl in control.Controls.Cast<Control>()) {
                    this.InitializeControlHierarchy(childControl);
                }
            }
        }
        private void InitializeDataBoundControl(object sender, EventArgs e) {
            var control = (DataBoundControl)sender;
            if (control != null) {
                control.DataBound -= this.InitializeDataBoundControl;
                this.InitializeControlHierarchy(control);
            }
        }
        private void InitializeUserControl(UserControl instance)
        {
            if (!this.alreadyInitializedControls.Contains(instance)) {
                WebFormsDependencyInjectionHttpModule.InitializeInstance(instance);
                // Ensure every user control is only initialized once.
                this.alreadyInitializedControls.Add(instance);
            }
        }
    }
