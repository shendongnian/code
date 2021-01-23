    public class MySite : ISite, IUIService
    {
        public MySite(PropertyGrid propertyGrid)
        {
            PropertyGrid = propertyGrid;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IUIService))
                return this;
            return null;
        }
        // this is part of IUIService
        public DialogResult ShowDialog(Form form)
        {
            // Check the form passed here is the error dialog box.
            // It's type name should be GridErrorDlg.
            // You can also scan all controls and for example
            // remove or modify some buttons...
            DialogResult result = form.ShowDialog(PropertyGrid);
            if (form.GetType().Name == "GridErrorDlg" && result == DialogResult.OK)
            {
                PropertyGrid.Refresh();
            }
            return result;
        }
        public PropertyGrid PropertyGrid { get; private set; }
        public bool DesignMode { get { return false; } }
        public IContainer Container { get { return null; } }
        public bool CanShowComponentEditor(object component) { return false; }
        // I've left the rest as not implemented, but make sure the whole thing works in your context...
        public IComponent Component
        {
            get { throw new NotImplementedException(); }
        }
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public IWin32Window GetDialogOwnerWindow()
        {
            throw new NotImplementedException();
        }
        public void SetUIDirty()
        {
            throw new NotImplementedException();
        }
        public bool ShowComponentEditor(object component, IWin32Window parent)
        {
            throw new NotImplementedException();
        }
        public void ShowError(Exception ex, string message)
        {
            throw new NotImplementedException();
        }
        public void ShowError(Exception ex)
        {
            throw new NotImplementedException();
        }
        public void ShowError(string message)
        {
            throw new NotImplementedException();
        }
        public DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons)
        {
            throw new NotImplementedException();
        }
        public void ShowMessage(string message, string caption)
        {
            throw new NotImplementedException();
        }
        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
        public bool ShowToolWindow(Guid toolWindow)
        {
            throw new NotImplementedException();
        }
        public System.Collections.IDictionary Styles
        {
            get { throw new NotImplementedException(); }
        }
    }
