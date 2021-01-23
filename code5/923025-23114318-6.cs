    public static class MasterPageExtensions
    {
        public static string GetHiddenFieldValue(this MasterPage master)
        {
            if (master is SubMasterPage)
                return (master as SubMasterPage).HiddenFieldValue;
            else
                return string.Empty;
        }
    }
    
    public class SubMasterPage : MasterPage
    {
        private HiddenField _hiddenField;
    
        public string HiddenFieldValue
        {
            get
            {
                return _hiddenField.Value;
            }
        }
    }
    
    public class ChildPage : Page
    {
        void TestMethod()
        {
            string hiddenValue = this.Master.GetHiddenFieldValue();
        }
    }
