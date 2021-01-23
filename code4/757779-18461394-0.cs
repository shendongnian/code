    private readonly Context _context = new Context(); 
    private void RibbonComposeMail_Load(object sender, RibbonUIEventArgs e)
    {
        try
        {
            var inspector = _context as Outlook.Inspector;
            if (inspector == null)
            {
                throw new ApplicationException("Fail - Step 1");
            }
    
            var currentMailItem = inspector.CurrentItem as Outlook.MailItem;
            if (currentMailItem == null)
            {
                throw new ApplicationException("Fail - Step 2");
            }
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
