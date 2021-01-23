        namespace C_Sharp_CHM
    {
      /// <summary>
      /// Using C# und CHM files.
      /// </summary>
      public partial class frmMain : Form
      {
        private const string sHTMLHelpFileName_ShowSingleHelpWindow = @"\help\CHM-example_ShowSingleHelpWindow.chm";
        private const string sHTMLHelpFileName_ShowWithNavigationPane = @"\help\CHM-example_ShowWithNavigationPane.chm";
        private const string sHTMLHelpFileName_ShowWithoutAutoSync = @"\help\CHM-example.chm";
        
        public frmMain()
        {
          InitializeComponent();
        }
       ...
      
        
      private void frmMain_Load(object sender, EventArgs e)
      {
        // example: System.Diagnostics.Process.Start(Application.StartupPath + sHTMLHelpFileName_ShowWithoutAutoSync);
        webBrowser1.Navigate(new Uri(GetChmUrl(Application.StartupPath + sHTMLHelpFileName_ShowWithoutAutoSync, "Garden/garden.htm")));
      
        if ((chkShowHelpWithNavigationPane.Checked == true))
        {
          helpProvider1.HelpNamespace = Application.StartupPath + sHTMLHelpFileName_ShowWithoutAutoSync;
        }
        else
        {
          helpProvider1.HelpNamespace = Application.StartupPath + sHTMLHelpFileName_ShowSingleHelpWindow;
        }
        // set F1 help topic for this form
        helpProvider1.SetHelpNavigator(this, HelpNavigator.Topic);
        helpProvider1.SetHelpKeyword(this, @"index.htm");
        // and set F1 help topic for some controls of this form  (two lines per control)
        helpProvider1.SetHelpNavigator(this.btnPopulate, HelpNavigator.Topic);
        helpProvider1.SetHelpKeyword(this.btnPopulate, @"/Garden/flowers.htm");
        helpProvider1.SetHelpNavigator(this.btnExit, HelpNavigator.Topic);
        helpProvider1.SetHelpKeyword(this.btnExit, @"/Garden/tree.htm");
        helpProvider1.SetHelpNavigator(this.chkShowHelpWithNavigationPane, HelpNavigator.Topic);
        helpProvider1.SetHelpKeyword(this.chkShowHelpWithNavigationPane, @"/HTMLHelp_Examples/jump_to_anchor.htm#AnchorSample");
        helpProvider1.SetHelpNavigator(this.btnOpenHelpShowTopic, HelpNavigator.Topic);
        helpProvider1.SetHelpKeyword(this.btnOpenHelpShowTopic, @"/HTMLHelp_Examples/image_and_text.htm");
      }
      
      private void btnOpenHelpShowTopic_Click(object sender, EventArgs e)
      {
        Help.ShowHelp(this.btnOpenHelpShowTopic, helpProvider1.HelpNamespace, HelpNavigator.Topic, @"/HTMLHelp_Examples/image_and_text.htm");
      }
