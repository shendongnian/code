    public partial class UIMap
    {
        public void DoLoginWithWait()
        {
            #region Variable Declarations
            WpfButton uILoginButton = this.UIMPortPodGUIWindow.UIItemCustom7.UIContinueButton;
            #endregion
            uILoginButton.WaitForControlExist(100);
            // Click 'Continue' button
            Mouse.Click(uILoginButton, new Point(191, 42));
        }
    }
